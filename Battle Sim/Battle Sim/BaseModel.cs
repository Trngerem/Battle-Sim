using System;

namespace BattleSim
{
    public class BaseModel
    {
        protected string Name { get; set; } = "Default";
        protected int MaxHealth { get; set; } = 100;
        protected int Attack { get; set; } = 10;
        protected int Defense { get; set; } = 5;
        protected int Health { get; set; } = 100;
        protected string Status { get; set; }
        protected int StatusDuration { get; set; }

        // Public getter methods
        public string GetName() => Name;
        public int GetHealth() => Health;
        public int GetAttack() => Attack;
        public int GetDefense() => Defense;

        // Adding a public constructor to make it accessible
        public BaseModel()
        {
        }

        public void AttackEnemy(BaseModel enemy)
        {
            Console.WriteLine($"{this.Name} has attacked {enemy.Name}!");
            int damage = this.Attack - enemy.Defense;
            enemy.TakeDamage(damage);
            Console.WriteLine();
        }

        public void AttackEnemy(BaseModel enemy, string spell)
        {
            Console.WriteLine($"{this.Name} has attacked {enemy.Name} with {spell}!");
            int damage = 0;
            if (spell == "icebeam")
            {
                damage = this.Attack - enemy.Defense - 4;

                if (enemy.StatusDuration == 0)
                {
                    enemy.Status = "";
                }

                Random random = new Random();
                if (random.Next(1, 6) == 1) // 1 out of 5 chance
                {
                    Console.WriteLine($"{enemy.Name} was frozen!");
                    enemy.Status = "Frozen";
                    enemy.StatusDuration = 1;
                }
            }
            if (spell == "fireball")
            {
                damage = this.Attack - enemy.Defense;

                Random random = new Random();
                if (random.Next(1, 6) == 1) // 1 out of 5 chance
                {
                    Console.WriteLine($"{enemy.Name} was burned");
                    enemy.Status = "Burned";
                    enemy.StatusDuration = 2;
                }
            }
            enemy.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            if (IsCriticalHit())
            {
                damage += 3;
                Console.WriteLine("Critical Hit!");
            }

            this.Health -= damage;
            Console.WriteLine($"{this.Name} has taken {damage} damage!");
            this.DisplayHealth();
            if (this.Health <= 0)
            {
                this.Health = 0;
                Console.WriteLine($"{this.Name} has been defeated!");
            }
            Console.WriteLine();
        }

        public bool IsCriticalHit()
        {
            Random random = new Random();
            return random.Next(1, 101) <= 20;  // 20% chance for a crit
        }

        public bool StatusEffect()
        {
            if (this.Status == "Burned")
            {
                this.Health -= 5;
                this.StatusDuration -= 1;
                Console.WriteLine($"{this.Name} is burned and takes 5 damage!");
                if (this.StatusDuration == 0)
                {
                    Console.WriteLine($"{this.Name} is no longer burnt");
                    this.Status = "";
                }
                DisplayHealth();
            }
            if (this.Status == "Frozen")
            {
                Console.WriteLine($"{this.Name} is frozen and cannot move!");
                if (this.StatusDuration == 0)
                {
                    this.Status = "";
                    Console.WriteLine($"The {this.Name} Wolf has thawed out!");
                    return false;
                }
                this.StatusDuration--;
                return true;
            }
            return false;
        }

        public void DisplayHealth()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Name: {0}", this.Name);
            Console.WriteLine("Health: {0}", this.Health);
            Console.WriteLine("---------------------");
            Console.WriteLine();
        }

        public void DisplayStats()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Health: {this.Health}");
            Console.WriteLine($"Attack: {this.Attack}");
            Console.WriteLine($"Defense: {this.Defense}");
            Console.WriteLine("---------------------");
            Console.WriteLine();
        }
    }
}
