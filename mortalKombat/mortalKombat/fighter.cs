using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mortalKombat
{
    class fighter
    {
        protected string name;
        protected double maxHealth;
        protected double health;
        protected double damage;
        protected double currDamage;
        protected int stunnedRounds;
        protected int mana;

       

        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }
        public int StunnedRounds
        {
            get { return stunnedRounds; }
            set { stunnedRounds = value; }
        }
        public string Name
        {
            get{return this.name; }
            set{this.name = value;}
        }
        public double Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
        public double MaxHealth
        {
            get { return this.maxHealth; }
            set { this.maxHealth = value; }
        }
        public double Damage
        {
            get { return damage; }
            set{this.damage = value;}
        }
        public double CurrDamage
        {
            get { return currDamage; }
            set { this.currDamage = value; }
        }


        public fighter(string name, double maxHealth, double damage)
        {
            this.name = name;
            this.maxHealth = maxHealth;
            this.damage = damage;
            
        }
        

        public bool fight(fighter enemy)
        {
            
            this.health = this.maxHealth;
            enemy.health = enemy.maxHealth;
            this.Mana = 0;
            enemy.Mana = 0;

            List<hit> hits = new List<hit>();
            hits.Add(new hit(50, 2, "High Kick"));//0
            hits.Add(new hit(75, 1.35, "Low Kick"));//1
            hits.Add(new hit(60, 1.75, "High Punch"));//2
            hits.Add(new hit(100, 1, "Low Punch"));//3
            hits.Add(new hit(100, 0.1, "Block"));//4
            hits.Add(new Spell(100, 0, "Ice Bolt", 2, 30));//5
            hits.Add(new Spell(80, 0.5, "Zap", 1, 10));//6

            Console.WriteLine("input action:");
            Console.WriteLine("e-high kick");
            Console.WriteLine("d-low kick");
            Console.WriteLine("q-high punch");
            Console.WriteLine("a-low punch");
            Console.WriteLine("s-block");
            Console.WriteLine("w-ice bolt(30MP)");
            Console.WriteLine("f-zap(10MP)");

            Console.WriteLine(this.name + " " + this.health + "   " + enemy.health + " " + enemy.name);
            
            while (true)
            {
               
                ConsoleKeyInfo act = Console.ReadKey();
                Console.WriteLine();


                this.currDamage = this.damage;
                enemy.currDamage = enemy.damage;
                    switch (act.KeyChar)//playerHitting
                    {
                        case 'e':
                            {
                                this.currDamage = hits[0].attack(this.damage);
                                this.Mana += 10;
                                break;
                            }

                        case 'd':
                            {
                                this.currDamage = hits[1].attack(this.damage);
                                this.Mana += 10;
                                break;
                            }

                        case 'q':
                            {
                                this.currDamage = hits[2].attack(this.damage);
                                this.Mana += 10;
                                break;
                            }

                        case 'a':
                            {
                                this.currDamage = hits[3].attack(this.damage);
                                this.Mana += 10;
                                break;
                            }

                        case 's':
                            {
                                this.currDamage = 0;
                                enemy.currDamage = hits[4].attack(enemy.damage);
                                this.Mana += 5;
                                break;
                                
                            }

                        case 'w':
                            {
                                if (this.Mana >= 30)
                                {
                                    this.Mana -= 30;
                                    enemy.StunnedRounds += 3;
                                    this.currDamage = hits[5].attack(this.Damage);
                                }
                                else Console.WriteLine("not enough mana!");
                                break;
                            }

                        case 'f':
                            {
                                if (this.Mana >= 10)
                                {
                                    this.Mana -= 10;
                                    this.currDamage = hits[6].attack(this.Damage);
                                    if(this.CurrDamage>0)
                                        enemy.StunnedRounds += 1;
                                }
                                else Console.WriteLine("not enough mana!");
                                break;
                            }

                        default:
                            {
                                this.currDamage = 0;
                                Console.WriteLine("stop doing nothing and hit the enemy!");
                                break;
                            }

                    }

                   
               if(this.checkStunned())
               { this.CurrDamage = 0; }
               if (enemy.checkStunned())
               { enemy.CurrDamage = 0; }


                    enemy.health -= this.currDamage;
                    this.health -= enemy.currDamage;

                

           //results
                    Console.WriteLine();
                    Console.WriteLine(this.name + " " +this.Mana+ "MP  " + this.health + "HP    " + enemy.health + " " + enemy.name);
                if (this.health <= 0 && enemy.health <= 0)
                {
                    Console.WriteLine("draw!");
                    return false;
                }
                if (this.health <= 0)
                {
                    Console.WriteLine("enemy won with "+enemy.health+" HP");
                    Console.WriteLine();
                    return false;
                }

                if (enemy.health <= 0)
                {
                    Console.WriteLine("you won with "+this.health+" HP");
                    Console.WriteLine();
                    return true;
                }
               
                
            }
        }

        public bool checkStunned()
        {
            if (this.stunnedRounds > 0)
            {
                StunnedRounds--;
                return true;
            }
            else return false;
        }


    }
}
