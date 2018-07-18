using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mortalKombat
{
    class Program
    {
        static void Buff(fighter player)
        {
            Console.WriteLine("1 - max health + 20%");
            Console.WriteLine("2 - damage +25%");
            Console.WriteLine();
            int choice;

          inp:

            try 
            {
                    choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("input the right one");
                goto inp;
            }
      
        
            if ( choice == 1)
                player.MaxHealth *= 1.2;
            else if (choice == 2)
                player.Damage *= 1.25;
            else
            {
                Console.WriteLine("input the right one");
                goto inp;
            }

        }

        static void Main()
        {
            List<fighter> LadderEasy = new List<fighter>();

            LadderEasy.Add(new fighter("raiden", 100, 8));
            LadderEasy.Add(new fighter("scorpion", 110, 9));
            LadderEasy.Add(new fighter("motaro", 150, 10));
            LadderEasy.Add(new fighter("Shao-Khan", 180, 12));

        start:
            fighter player = new fighter("player", 100, 10);
            Console.WriteLine("press any key to start");
            Console.ReadKey();

            for (int i = 0; i < LadderEasy.Count; i++)
            {
                if (player.fight(LadderEasy[i]))
                    Buff(player);
                else goto start;
                
            }
            
            
            Console.WriteLine("you beat everyone!");

        }
    }
}
