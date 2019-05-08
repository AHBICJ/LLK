using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LLK
{
    class BlockMap
    {
        public const int Width = 12;
        public const int Height = 12;
        public const int TotalBlocks = Width* Height;
        const int TotalImages = 39; // 图样总数
        public int BlockNum { get; set; }
        Block[,] blocks;              // 对应当前连连看布局
        public int this[int h,int w] { get =>blocks[h, w].Type; set =>blocks[h, w].Type=value; }
        public BlockMap()
        {
            blocks = new Block[Height + 2, Width + 2];
            InitBlocks();
            MessUp();
        }
        /// <summary>
        /// 对地图中的图形进行初始化，保证
        /// 1. 形是成对的 2. 边界一圈全部是0
        /// </summary>
        private void InitBlocks()
        {
            BlockNum=0;
            Random Ran = new Random();
            for (int h = 0; h <= Height + 1; h++)
                for (int w = 0; w <= Width + 1; w++)
                    blocks[h, w] = new Block(w, h);

            for (int h = 1; h <= Height; h++)
                for (int w = 1; w <= Width / 2; w++)
                    if (Ran.Next(0, 10) > 1)
                    {
                        blocks[h, w].Type = blocks[h, Width - w + 1].Type = Ran.Next(TotalImages) + 1;
                        BlockNum += 2;
                    }
        }

        /// <summary>
        /// 打乱地图
        /// </summary>
        internal void MessUp()
        {
            Random Ran = new Random();
            int times = Width * Height * 4;
            for (int i = 0; i < times; i++)
            {
                int a = 0;
                while (blocks[a / Width + 1, a % Width + 1].Type == 0) a = Ran.Next(TotalBlocks);
                int b = 0;
                while (blocks[b / Width + 1, b % Width + 1].Type == 0 || a==b) b = Ran.Next(TotalBlocks);
                int t = blocks[a / Width + 1, a % Width + 1].Type;
                blocks[a / Width + 1, a % Width + 1].Type = blocks[b / Width + 1, b % Width + 1].Type;
                blocks[b / Width + 1, b % Width + 1].Type = t;
            }
        }
        public Size GetMapSize()
        {
            return new Size((Width+2) * Block.BlockWidth, (Height+2) * Block.BlockHeight);
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public bool CanLink(int w1,int h1,int w2,int h2,out int aw,out int ah,out int bw,out int bh)
        {
            aw = ah = bw = bh = -1;
            if (CanDirectLink(w1, h1, w2, h2)) return true;
            if (CanOneLink(w1, h1, w2, h2,out aw, out ah)) return true;
            if (CanTwoLink(w1, h1, w2, h2,out aw, out ah, out bw, out bh)) return true;
            return false;
        }

        private bool CanTwoLink(int w1, int h1, int w2, int h2, out int aw, out int ah, out int bw,out int bh)
        {
            // 优化遍历思路 分四个方向 这样保证靠近方块
            // 向上
            aw = w1;
            for (ah = h1-1; ah >= 0; ah--){
                if (blocks[ah, aw].Type == 0){
                    if (CanOneLink(aw, ah, w2, h2, out bw, out bh)) return true;
                }else break;
            }
            // 向下
            for (ah = h1 + 1; ah <= Height+1; ah++)
            {
                if (blocks[ah, aw].Type == 0)
                {
                    if (CanOneLink(aw, ah, w2, h2, out bw, out bh)) return true;
                }
                else break;
            }
            // 向右
            ah = h1;
            for (aw = w1 + 1; aw <= Width + 1; aw++)
            {
                if (blocks[ah, aw].Type == 0)
                {
                    if (CanOneLink(aw, ah, w2, h2, out bw, out bh)) return true;
                }
                else break;
            }
            // 向左
            ah = h1;
            for (aw = w1 - 1; aw >= 0; aw--)
            {
                if (blocks[ah, aw].Type == 0)
                {
                    if (CanOneLink(aw, ah, w2, h2, out bw, out bh)) return true;
                }
                else break;
            }
            ah = aw = bh = bw = -1;
            return false;
        }

        private bool CanOneLink(int w1, int h1, int w2, int h2, out int aw, out int ah)
        {
            // h2 w1
            if (blocks[h2, w1].Type == 0 && CanDirectLink(w1, h1, w1, h2) && CanDirectLink(w2, h2, w1, h2))
            {
                aw = w1; ah = h2;
                return true;
            }
            // h1 w2
            if (blocks[h1, w2].Type == 0 &&  CanDirectLink(w1, h1, w2, h1) && CanDirectLink(w2, h2, w2, h1))
            {
                aw = w2; ah = h1;
                return true;
            }
            aw = ah = -1;
            return false;
        }

        private bool CanDirectLink(int w1, int h1, int w2, int h2)
        {
            if (w1 != w2 && h1!=h2) return false;
            if (w1 == w2)
            {
                for (int h = Math.Min(h1, h2) + 1; h < Math.Max(h1, h2); h++)
                {
                    if (blocks[h, w1].Type != 0) return false;
                }
                return true;
            }
            if (h1 == h2) {
                for (int w= Math.Min(w1, w2) + 1; w < Math.Max(w1, w2); w++)
                {
                    if (blocks[h1, w].Type != 0) return false;
                }
                return true;
            }
            return false; // keep safe;
        }
        internal bool getTip(out int aw,out int ah,out int bw,out int bh)
        {
            List<Block> bs = new List<Block>();
            aw = ah = bw = bh = -1;
            int t1, t2, t3, t4;
            for (int j=1;j<=Height;j++)
                for (int i = 1; i <= Width; i++)
                {
                    if (blocks[j, i].Type != 0) bs.Add(blocks[j,i]);
                }
            for (int i = 0; i < bs.Count; i++)
            {
                for (int j=i+1; j < bs.Count; j++)
                {
                    if (bs[i].Type != bs[j].Type) continue;
                    if (CanLink(bs[i].X,bs[i].Y,bs[j].X,bs[j].Y,out t1,out t2,out t3,out t4))
                    {
                        aw = bs[i].X; ah = bs[i].Y;
                        bw = bs[j].X; bh = bs[j].Y;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
