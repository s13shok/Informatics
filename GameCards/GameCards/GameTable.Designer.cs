namespace GameCards
{
    partial class GameTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameTable));
            this.cards = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // cards
            // 
            this.cards.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("cards.ImageStream")));
            this.cards.TransparentColor = System.Drawing.Color.Transparent;
            this.cards.Images.SetKeyName(0, "purple_back.png");
            this.cards.Images.SetKeyName(1, "6C.png");
            this.cards.Images.SetKeyName(2, "6D.png");
            this.cards.Images.SetKeyName(3, "6H.png");
            this.cards.Images.SetKeyName(4, "6S.png");
            this.cards.Images.SetKeyName(5, "7C.png");
            this.cards.Images.SetKeyName(6, "7D.png");
            this.cards.Images.SetKeyName(7, "7H.png");
            this.cards.Images.SetKeyName(8, "7S.png");
            this.cards.Images.SetKeyName(9, "8C.png");
            this.cards.Images.SetKeyName(10, "8D.png");
            this.cards.Images.SetKeyName(11, "8H.png");
            this.cards.Images.SetKeyName(12, "8S.png");
            this.cards.Images.SetKeyName(13, "9C.png");
            this.cards.Images.SetKeyName(14, "9D.png");
            this.cards.Images.SetKeyName(15, "9H.png");
            this.cards.Images.SetKeyName(16, "9S.png");
            this.cards.Images.SetKeyName(17, "10C.png");
            this.cards.Images.SetKeyName(18, "10D.png");
            this.cards.Images.SetKeyName(19, "10H.png");
            this.cards.Images.SetKeyName(20, "10S.png");
            this.cards.Images.SetKeyName(21, "AC.png");
            this.cards.Images.SetKeyName(22, "AD.png");
            this.cards.Images.SetKeyName(23, "AH.png");
            this.cards.Images.SetKeyName(24, "AS.png");
            this.cards.Images.SetKeyName(25, "JC.png");
            this.cards.Images.SetKeyName(26, "JD.png");
            this.cards.Images.SetKeyName(27, "JH.png");
            this.cards.Images.SetKeyName(28, "JS.png");
            this.cards.Images.SetKeyName(29, "KC.png");
            this.cards.Images.SetKeyName(30, "KD.png");
            this.cards.Images.SetKeyName(31, "KH.png");
            this.cards.Images.SetKeyName(32, "KS.png");
            this.cards.Images.SetKeyName(33, "QC.png");
            this.cards.Images.SetKeyName(34, "QD.png");
            this.cards.Images.SetKeyName(35, "QH.png");
            this.cards.Images.SetKeyName(36, "QS.png");
            // 
            // GameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(855, 454);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "GameTable";
            this.Text = "Game table with cards";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GameTable_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameTable_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameTable_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameTable_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameTable_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList cards;
    }
}

