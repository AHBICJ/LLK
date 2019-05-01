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
        
        public Main()
        {
            InitializeComponent();
        }

        private void Pause_Click(object sender, EventArgs e)
        {

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

            Console.WriteLine("_" + map[preh, prew] + "_L2");
            if (map[preh, prew] != 0)
            {
                image = (Bitmap)rm.GetObject("_" + map[preh, prew] + "_L2");
                g.DrawImage(image, Block.BlockWidth * prew, Block.BlockHeight * preh);
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
        }

        private void Boom(int ww,int hh, int w, int h, Point[] points)
        {
            Pen pen = new Pen(Color.Red);
            Graphics g = GameBox.CreateGraphics();
            Image image;
            SoundPlayer player;
            player = new SoundPlayer("Sound/elec.wav");
            player.Play();
            for (int i = 1; i <= 6; ++i)
            {
                image = (Bitmap)rm.GetObject("B" + i);
                if (i<=3) g.DrawLines(pen, points);
                g.DrawImage(image, Block.BlockWidth * ww, Block.BlockHeight * hh, Block.BlockWidth, Block.BlockHeight);
                g.DrawImage(image, Block.BlockWidth * w, Block.BlockHeight * h, Block.BlockWidth, Block.BlockHeight);
                Thread.Sleep(150);
            }
            GameBox.Invalidate();
        }
        private void GameBox_MouseClick(object sender, MouseEventArgs e)
        {
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
                // 直连
                List<Point> points = new List<Point>();
                points.Add(new Point(prew * Block.BlockWidth + Block.BlockWidth / 2, preh * Block.BlockHeight + Block.BlockHeight / 2));                
                if (aw != -1) points.Add(new Point(aw * Block.BlockWidth + Block.BlockWidth / 2, ah * Block.BlockHeight + Block.BlockHeight / 2));
                if (bw != -1) points.Add(new Point(bw * Block.BlockWidth + Block.BlockWidth / 2, bh * Block.BlockHeight + Block.BlockHeight / 2));
                points.Add(new Point(w * Block.BlockWidth + Block.BlockWidth / 2, h * Block.BlockHeight + Block.BlockHeight / 2));
                map[preh, prew] = map[h, w] = 0;

                int hh = preh, ww = prew;
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
