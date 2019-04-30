using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLK
{
    class Block
    {
        int x, y;
        internal const int BlockHeight = 34;
        internal const int BlockWidth = 31;
        public int X { get => x; }
        public int Y { get => y; }
        public Block(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
