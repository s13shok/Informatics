using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable
{
    public partial class TimeTable : Form
    {
        public TimeTable()
        {
            InitializeComponent();
        }

        private void TimeTable_Load(object sender, EventArgs e)
        {
            var add_Button = new Button();

            this.add_Button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.add_Button.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_Button.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_Button.ForeColor = System.Drawing.Color.Green;
            this.add_Button.Location = new System.Drawing.Point(271, 3);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(100, 48);
            this.add_Button.Text = "OK";
            this.add_Button.UseVisualStyleBackColor = false;
            tableLayoutPanel3.Controls.Add(add_Button, 0, 0);
        }
    }
}
