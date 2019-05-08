using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLK
{
    class Game
    {
        public int Prew { get; set; }
        public int Preh { get; set; }
        public bool TipOn { get; set; } = false;
        public int Tipaw { get; set; }
        public int Tipah { get; set; }
        public int Tipbw { get; set; }
        public int Tipbh { get; set; }
        public long PreHit { get; set; }
        public int Combo { get; set; }
        public int Score { get; set; }
        public int MaxCombo { get; set; }
        public Game()
        {
            Prew = 0;
            Preh = 0;
            Tipaw = 0;
            Tipah = 0;
            Tipbw = 0;
            Tipbh = 0;
            PreHit = DateTime.Now.Ticks;
            Combo = 0;
            Score = 0;
            MaxCombo = 0;
        }

    }
}
