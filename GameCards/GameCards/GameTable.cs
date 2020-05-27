using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GameCards
{
    public partial class GameTable : Form
    {
        public GameTable()
        {
            InitializeComponent();
        }

        bool isDown = false;
        Bitmap table;
        Bitmap[] cardsBit = new Bitmap[36];
        int cnt = 1;

        private void DrawElements()
        {
            var graphics = CreateGraphics();
            var buffGraphics = Graphics.FromImage(table);
            buffGraphics.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ClientRectangle.Width, ClientRectangle.Height), Color.DarkKhaki, Color.LimeGreen), ClientRectangle);
            buffGraphics.DrawImage(new Bitmap(cards.Images[0]), 40, 70);
            buffGraphics.Dispose();
            graphics.DrawImage(table, 0, 0);
        }

        private void GameTable_Load(object sender, EventArgs e)
        {
            table = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            DrawElements();
            BackgroundImage = table;
            table = new Bitmap(BackgroundImage);
            for (int i = 0; i < cardsBit.Length; i++)
            {
                cardsBit[i] = new Bitmap(cards.Images[i + 1]);
            }
            //Shuffle the deck
            var rand = new Random();
            for (int i = cardsBit.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i);
                var card = cardsBit[i];
                cardsBit[i] = cardsBit[j];
                cardsBit[j] = card;
            }
        }

        private void GameTable_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Location.X > 40 && e.Location.Y > 70) && (e.Location.X < 220 && e.Location.Y < 326))
            {
                isDown = true;
            }
            else if(e.Location.X < 40 && e.Location.Y < 70)
            {
                MessageBox.Show("Ⓒs13shok - https://github.com/s13shok");
                System.Diagnostics.Process.Start("https://github.com/s13shok/Informatics/tree/master/GameCards");
            }
        }

        private void GameTable_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDown)
            {
                GameTable_MouseDown(sender, e);
                var graphics = CreateGraphics();
                var buffGr = Graphics.FromImage(table);
                buffGr.DrawImage(cards.Images[0], MousePosition.X - 100, MousePosition.Y - 100);
                buffGr.Dispose();
                graphics.DrawImage(table, 0, 0);
                table = new Bitmap(BackgroundImage);
            }
        }

        private void GameTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (cnt == 36)
            {
                MessageBox.Show("Карты закончились. Для обновления стола нажмите F2");
            }
            else if (isDown)
            {
                isDown = false;
                var graphics = CreateGraphics();
                var buffGr = Graphics.FromImage(BackgroundImage);
                buffGr.TranslateTransform(cardsBit[cnt].Width, cardsBit[cnt].Height);
                var rnd = new Random();
                buffGr.RotateTransform(rnd.Next(-30, 30));
                buffGr.DrawImage(cardsBit[cnt], MousePosition.X - 350, MousePosition.Y - 350);
                buffGr.Dispose();
                graphics.DrawImage(BackgroundImage, 0, 0);
                table = new Bitmap(BackgroundImage);
                cnt++;
            }
        }

        private void GameTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                cnt = 1;
                DrawElements();
                BackgroundImage = table;
                table = new Bitmap(BackgroundImage);
            }
        }
    }
}
