using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DirectoryBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


        }
        public const string GraphicsFormats = "BMP, ECW, GIF, ICO, ILBM, JPEG, JPG, VIL, MRSID, PCX, PNG, PSD, TGA, TIFF, WEBP, XBM, XPS, RLA, RPF, PNM";
        public const string OfficeFormats = "DOCX, DOCM, DOTX, DOTM, XLSX, XLSM, XLTX , XLTM, XLSB, XLAM, PPTX , PPTM, PPSX, PPSM, POTX, POTM, PPAM, TXT, PDF, HTML, CS, CSS";
        public const string ArchiveFormats = "ZIP, JAR, 7Z, RAR, GZ";
        public const string ExeFormats = "EXE, DLL";
        private void Build(TreeNode parent)
        {
            var path = parent.Tag as string;
            parent.Nodes.Clear();
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    parent.Nodes.Add(new TreeNode(Path.GetFileName(dir), new[] { new TreeNode("...") }) { Tag = dir });
                }
                foreach (var file in Directory.GetFiles(path))
                {
                    parent.Nodes.Add(new TreeNode(Path.GetFileName(file), 1, 1) { Tag = file });
                }
            }
            catch
            {
            }
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Build(e.Node);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            var browser = new FolderBrowserDialog();
            if (browser.ShowDialog(this) == DialogResult.OK)
            {
                var root = new TreeNode() { Text = $@"{browser.SelectedPath}", Tag = $@"{browser.SelectedPath}" };
                treeView1.Nodes.Add(root);
                Build(root);
                root.Expand();
            }
        }

        private void eXitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            var sb = new StringBuilder();
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                sb.Clear();
                var path = GetPathToNode(e.Node, sb) + e.Node.Text + @"\" + e.Node.Nodes[i].Text;
                path.Replace(@"\\", @"\");
                try
                {
                    if (Path.HasExtension(path))
                    {
                        var fileInfo = new FileInfo(path);
                        var file = new ListViewItem(fileInfo.Name);
                        file.SubItems.Add(fileInfo.Length.ToString());
                        file.SubItems.Add(fileInfo.Extension.Remove(0, 1));
                        file.Checked = true;
                        listView1.Items.Add(file);
                    }
                }
                catch
                {
                }
            }
            listView1.Refresh();
            listView1.Margin = new Padding(2);
            listView1.Margin = new Padding(3);
        }
        private string GetPathToNode(TreeNode node, StringBuilder sb)
        {
            if (node.Parent == null)
            {
                return sb.ToString();
            }
            else
            {
                sb.Insert(0, node.Parent.Text + @"\");
                return GetPathToNode(node.Parent, sb);
            }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Expand();
        }
        
        private void listView1_MarginChanged(object sender, EventArgs e)
        {
            Dictionary<string, int> extensions = new Dictionary<string, int>(listView1.Items.Count);
            chart1.Series[0].Points.Clear();
            var checkedItems = 0;
            decimal totalBytes = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                try { totalBytes += Convert.ToInt32(listView1.Items[i].SubItems[1].Text); } catch { }
                if (listView1.Items[i].Checked)
                {
                    checkedItems++;
                    try
                    {
                        extensions[listView1.Items[i].SubItems[2].Text] += (listView1.Items[i].SubItems[0].Text.IndexOf('.') * 100 + 1);
                    }
                    catch
                    {
                        extensions.Add(listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[0].Text.IndexOf('.') * 100 + 1);
                    }
                }
                if (GraphicsFormats.Contains(listView1.Items[i].SubItems[2].Text.ToUpper()))
                {
                    listView1.Items[i].BackColor = Color.FromArgb(101, 225, 123);
                }
                else if (OfficeFormats.Contains(listView1.Items[i].SubItems[2].Text.ToUpper()))
                {
                    listView1.Items[i].BackColor = Color.FromArgb(255, 125, 115);
                }
                else if (ExeFormats.Contains(listView1.Items[i].SubItems[2].Text.ToUpper()))
                {
                    listView1.Items[i].BackColor = Color.FromArgb(255, 231, 115);
                }
                else if (ArchiveFormats.Contains(listView1.Items[i].SubItems[2].Text.ToUpper()))
                {
                    listView1.Items[i].BackColor = Color.FromArgb(135, 110, 215);
                }
                else
                {
                    listView1.Items[i].BackColor = Color.FromArgb(128, 128, 128);
                }
            }
            toolStripStatusLabel2.Text = $"{checkedItems} of {listView1.Items.Count} items selected";
            toolStripStatusLabel1.Text = $"Total bytes:{totalBytes}";
            foreach (string key in extensions.Keys)
            {
                chart1.Series[0].Points.AddXY(key, extensions[key] / 100 / (double)(extensions[key] % 100));
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Dictionary<string, int> extensions = new Dictionary<string, int>(listView1.Items.Count);
            chart1.Series[0].Points.Clear();
            var checkedItems = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked)
                {
                    checkedItems++;
                    try
                    {
                        extensions[listView1.Items[i].SubItems[2].Text] += (listView1.Items[i].SubItems[0].Text.IndexOf('.') * 100 + 1);
                    }
                    catch
                    {
                        extensions.Add(listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[0].Text.IndexOf('.') * 100 + 1);
                    }
                }
            }
            toolStripStatusLabel2.Text = $"{checkedItems} of {listView1.Items.Count} items selected";
            foreach (string key in extensions.Keys)
            {
                chart1.Series[0].Points.AddXY(key, extensions[key] / 100 / (double)(extensions[key] % 100));
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Dictionary<string, int> extensions = new Dictionary<string, int>(listView1.Items.Count);
            chart1.Series[0].Points.Clear();
            var checkedItems = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked)
                {
                    checkedItems++;
                    try
                    {
                        extensions[listView1.Items[i].SubItems[2].Text] += (listView1.Items[i].SubItems[0].Text.IndexOf('.') * 100 + 1);
                    }
                    catch
                    {
                        extensions.Add(listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[0].Text.IndexOf('.') * 100 + 1);
                    }
                }
            }
            toolStripStatusLabel2.Text = $"{checkedItems} of {listView1.Items.Count} items selected";
            foreach (string key in extensions.Keys)
            {
                chart1.Series[0].Points.AddXY(key, extensions[key] / 100 / (double)(extensions[key] % 100));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                var saveDialog = new SaveFileDialog
                {
                    FileName = "FilesInfo",
                    DefaultExt = "txt",
                    AddExtension = true,
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(saveDialog.FileName))
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            sw.WriteLine($"{listView1.Items[i].SubItems[0].Text} | {listView1.Items[i].SubItems[1].Text} | {listView1.Items[i].SubItems[2].Text}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a folder to open files");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                listView1.Font = fontDialog.Font;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontToolStripMenuItem1_Click(sender, e);
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                listView1.ForeColor = colorDialog.Color;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorToolStripMenuItem1_Click(sender, e);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/s13shok");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            helpToolStripMenuItem_Click(sender, e);
        }
    }
}
