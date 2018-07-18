using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mortalKombat
{
    public class Spell : hit
    {
        
        protected int stunDuration;
        public int StunDuration
        {
            get { return stunDuration; }
            set { stunDuration = value; }
        }

        protected int manaCost;
        public int ManaCost
        {
            get { return manaCost; }
            set { manaCost = value; }
        }
        
      
        public Spell(int chance, double coef, string name, int stunDuration, int manaCost) : base(chance,coef,name)
         {
            
            this.chance = chance;
            this.coef = coef;
            this.name = name;
            this.stunDuration = stunDuration;
            this.manaCost = manaCost;
         }


        
    }
}
