
namespace BattleSim
{
    public class Wolf : BaseModel
    {
        public Wolf(string Name, int MaxHealth, int Attack, int Defense)
        {
            this.Name = Name;
            this.MaxHealth = MaxHealth;
            this.Health = MaxHealth;
            this.Attack = Attack;
            this.Defense = Defense;
        }

        public void Turn(Wizard Wizard)
        {
            if (this.Health > 0)
            {
                if (!this.StatusEffect())
                    this.AttackEnemy(Wizard);

            }
        }
    }
}
