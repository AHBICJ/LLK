using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLK
{
    public partial class Main : Form
    {
        BlockMap map;
        ResourceManager rm = Images.ResourceManager;
        private int prew = 0,preh = 0;

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

        private void GameBox_MouseClick(object sender, MouseEventArgs e)
        {
            int h = e.Y / Block.BlockHeight;
            int w = e.X / Block.BlockWidth;
            int ax, ay, bx, by;
            if (map[h, w] == 0) return;
            if (h == preh && w == prew)
            {
                preh = 0;
                prew = 0;
            }
            else if (map[preh, prew] == map[h, w] && map.CanLink(prew, preh, w, h,out ax,out ay,out bx,out by))
            {
                // 直连
                if (ax == -1)
                {
                    map[preh, prew] = map[h, w] = 0;
                    preh = 0; prew = 0;
                }
                // 一折
                else if (bx == -1)
                {
                    map[preh, prew] = map[h, w] = 0;
                    preh = 0; prew = 0;
                }
                // 两折
                else
                {
                    map[preh, prew] = map[h, w] = 0;
                    preh = 0; prew = 0;
                }
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
