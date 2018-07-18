using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mortalKombat
{
    public class hit
    {
       
         protected int chance;
         protected double coef;
         protected string name;

         public int Chance
        {
            get { return chance; }
            set { this.chance = value; }

        }

         public double Coef
        {
            get { return coef; }
            set { this.coef = value; }

        }
        
         public string Name
         {
             get { return name; }
             set { name = value; }
         }


         public hit(int chance, double coef, string name)
         {
            
            this.chance = chance;
            this.coef = coef;
            this.name = name;
         }

         public double attack(double playerDamage)
        {
            Random rand = new Random();
            double damage;
            int success = rand.Next(0, 101);
            Console.Write("hit with "+this.name);
            if (success <= this.chance)
            {
                damage = playerDamage * this.coef;
                Console.WriteLine(" for "+damage+" damage");
            }
            else
            {
                damage = 0;
                Console.WriteLine(" (miss)");
            }


            return damage;

        }
    }
}
