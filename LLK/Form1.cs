using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLK
{
    public partial class Main : Form
    {
        BlockMap map;
        ResourceManager rm = Images.ResourceManager;
        int prew = 0,preh = 0;
        Random Ran = new Random(DateTime.Now.Millisecond);
        bool tipOn = false;
        int tipaw, tipah, tipbw, tipbh;
        int preHit;
        int combo;
        public Main()
        {
            InitializeComponent();
            Tip.Enabled = false;
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (Pause.Text == "暂停")
            {
                GameBox.Visible = false;
                Pause.Text = "继续";
            }
            else
            {
                GameBox.Visible = true;
                Pause.Text = "暂停";
            }
        }

        private void PaintMap(Graphics g)
        {
            if (map == null) return;
            Image image = null;
            for (int h = 1; h <= BlockMap.Height; h++)
            {
                for (int w = 1; w <= BlockMap.Width; w++)
                {
                    if (map[h, w] > 0)
                    {
                        image = (Bitmap)rm.GetObject("_" + map[h, w]);
                        g.DrawImage(image, Block.BlockWidth * w, Block.BlockHeight * h);
                    }
                }
            }

            //Console.WriteLine("_" + map[preh, prew] + "_L2");
            if (map[preh, prew] != 0)
            {
                image = (Bitmap)rm.GetObject("_" + map[preh, prew] + "_L2");
                g.DrawImage(image, Block.BlockWidth * prew, Block.BlockHeight * preh);
            }

            if (tipOn)
            {
                image = (Bitmap)rm.GetObject("_" + map[tipah, tipaw] + "_L2");
                g.DrawImage(image, Block.BlockWidth * tipaw, Block.BlockHeight * tipah);
                image = (Bitmap)rm.GetObject("_" + map[tipbh, tipbw] + "_L2");
                g.DrawImage(image, Block.BlockWidth * tipbw, Block.BlockHeight * tipbh);
            }

        }

        private void GameBox_Paint(object sender, PaintEventArgs e)
        {
            PaintMap(e.Graphics);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            map = new BlockMap();
            GameBox.Size = map.GetMapSize();
            Graphics g = GameBox.CreateGraphics();
            PaintMap(g);
            Start.Enabled = false;
            Tip.Enabled = true;
            preHit = DateTime.Now.Millisecond;
        }

        private void Boom(int ww,int hh, int w, int h, Point[] points)
        {
            Pen pen = new Pen(Color.Red);
            Graphics g = GameBox.CreateGraphics();
            Image image;
            SoundPlayer player;
            player = new SoundPlayer(string.Format("Sound/exp{0}.wav", Ran.Next(1, 3)));
            player.Play();
            for (int i = 1; i <= 6; ++i)
            {
                image = (Bitmap)rm.GetObject("B" + i);
                if (i<=3) g.DrawLines(pen, points);
                g.DrawImage(image, Block.BlockWidth * ww, Block.BlockHeight * hh, Block.BlockWidth, Block.BlockHeight);
                g.DrawImage(image, Block.BlockWidth * w, Block.BlockHeight * h, Block.BlockWidth, Block.BlockHeight);
                Thread.Sleep(100);
            }
            GameBox.Invalidate();
        }

        private void Tip_Click(object sender, EventArgs e)
        {
            if (map.getTip(out tipaw,out tipah,out tipbw,out tipbh))
            {
                tipOn = true;
                GameBox.Invalidate();
            }
        }

        private void GameBox_MouseClick(object sender, MouseEventArgs e)
        {
            tipOn = false;
            GameBox.Invalidate();
            int h = e.Y / Block.BlockHeight;
            int w = e.X / Block.BlockWidth;
            int aw, ah, bw, bh;
            if (map[h, w] == 0) return;
            if (h == preh && w == prew)
            {
                preh = 0; prew = 0;
            }
            else if (map[preh, prew] == map[h, w] && map.CanLink(prew, preh, w, h,out aw,out ah,out bw,out bh))
            {
                int timeNow = DateTime.Now.Millisecond;
                if (timeNow - preHit <= 1500) combo++;
                else combo = 0;
                // 直连
                List<Point> points = new List<Point>();
                points.Add(new Point(prew * Block.BlockWidth + Block.BlockWidth / 2, preh * Block.BlockHeight + Block.BlockHeight / 2));                
                if (aw != -1) points.Add(new Point(aw * Block.BlockWidth + Block.BlockWidth / 2, ah * Block.BlockHeight + Block.BlockHeight / 2));
                if (bw != -1) points.Add(new Point(bw * Block.BlockWidth + Block.BlockWidth / 2, bh * Block.BlockHeight + Block.BlockHeight / 2));
                points.Add(new Point(w * Block.BlockWidth + Block.BlockWidth / 2, h * Block.BlockHeight + Block.BlockHeight / 2));
                map[preh, prew] = map[h, w] = 0;

                int hh = preh, ww = prew;
                // 本来应该写一个类用来保存状态的 但是 一开始不知道 也懒得改了
                new Thread(()=>Boom(ww, hh, w, h, points.ToArray())).Start();
                preh = 0; prew = 0;
            }
            else
            {
                preh = h;
                prew = w;
            }
            GameBox.Invalidate();
            //Console.WriteLine(string.Format("{0} {1}",w,h));
        }

    }
}
