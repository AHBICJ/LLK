using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLK
{
    class Block
    {
        int x, y,type;
        internal const int BlockHeight = 34;
        internal const int BlockWidth = 31;
        public int X { get => x; }
        public int Y { get => y; }
        public int Type { get => type; set => type = value; }
        public Block(int x, int y,int type=0)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

    }
}
