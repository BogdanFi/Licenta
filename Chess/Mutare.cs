using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Mutare
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Value { get; set; }
        public int AttackValue { get; set; }
        public bool IsAttack { get; set; }
        public int KingPosition { get; set; }

        public Mutare()
        {
            To = 0;
            From = 0;
        }
        public Mutare (int from,int to, int value,bool attack)
        {
            this.From = from;
            this.To = to;
            this.Value = value;
            this.IsAttack = attack;
        }
    }
}
