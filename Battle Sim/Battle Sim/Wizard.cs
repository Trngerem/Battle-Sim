using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Characters
{
    public class Wizard : BaseModel
    {
        public int Mana { get; set; }

        public Wizard(string Name, int MaxHealth, int Attack, int Defense)
        {
            this.Name = Name;
            this.MaxHealth = MaxHealth;
            this.Health = MaxHealth;
            this.Attack = Attack;
            this.Defense = Defense;
            this.Mana = 1000;
        }

        public bool CastFireballSpell(Wolf wolf)
        {
            if (UseMana(15))
            {
                AttackEnemy(wolf, "fireball");
                return true;
            }
            else
                Console.WriteLine("Not enough mana to cast Fireball!");
            return false;
        }

        public bool Heal(int points)
        {
            if (UseMana(7))
            {
                if (Health + points > MaxHealth)
                {
                    Console.WriteLine($"{this.Name} has healed {this.MaxHealth - this.Health} hp!");
                    this.Health = this.MaxHealth;
                    Console.WriteLine($"{this.Name} is at full health!");
                }
                else
                {
                    Console.WriteLine($"{this.Name} has healed {points} hp!");
                    this.Health += points;
                }
                DisplayStats();
                return true;
            }
            else
                Console.WriteLine("Not enough mana to cast Heal!");
            return false;

        }

        public bool Strengthen(int points)
        {
            if (UseMana(5))
            {
                Console.WriteLine($"{this.Name} has powered up! (+{points} str)");
                this.Attack += points;
                DisplayStats();
                return true;
            }
            else
                Console.WriteLine("Not enough mana to cast Strengthen!");
            return false;

        }

        public bool Shield(int points)
        {
            if (UseMana(5))
            {
                Console.WriteLine($"{this.Name} has cast Shield! (+{points} def)");
                this.Defense += points;
                DisplayStats();
                return true;
            }
            else
                Console.WriteLine("Not enough mana to cast Shield!");

            return false;
        }

        public bool IceBeam(Wolf wolf)
        {
            if (UseMana(13))
            {
                AttackEnemy(wolf, "icebeam");
                return true;
            }
            else
                Console.WriteLine("Not enough mana to cast IceBeam!");
            return false;
        }

        public bool UseMana(int cost)
        {
            if (this.Mana - cost < 0)
            {
                Console.WriteLine("Not enough mana!");
                return false;
            }
            else
            {
                this.Mana -= cost;
                return true;
            }
        }

        public void PlayerTurn(Wolf Wolf)
        {
            while (this.Health > 0 && Wolf.GetHealth() > 0)
            {
                Console.WriteLine("choose your move");
                string input = Console.ReadLine();
                Console.Clear();

                if (input == "fireball")
                {
                    if (this.CastFireballSpell(Wolf) == false)
                    {
                        continue;
                    }
                }
                else if (input == "heal")
                {
                    if (this.Heal(20) == false)
                    {
                        continue;
                    }
                }
                else if (input == "icebeam")
                {
                    if (this.IceBeam(Wolf) == false)
                    {
                        continue;
                    }
                }
                else if (input == "shield")
                {
                    if (this.Shield(2) == false)
                    {
                        continue;
                    }
                }
                else if (input == "strengthen")
                {
                    if (this.Strengthen(2) == false)
                    {
                        continue;
                    }
                }
                else if (input == "stats")
                {
                    this.DisplayStats();
                    Wolf.DisplayStats();
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                Wolf.Turn(this); // Wolf attacks after every player move

                Console.WriteLine();
                Console.WriteLine("-----------");
                Console.WriteLine("Press Enter");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

}
