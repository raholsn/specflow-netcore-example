using System;

namespace Domain
{
    public class Player
    {
        public Guid Id { get;  }
        public Stats Stats { get;  }
        public bool IsDead { get; private set; }

        public Player(Stats stats)
        {
            Id = Guid.NewGuid();
            Stats = stats;
        }

        public void Attack(Player enemy)
        {
            var damage = Stats.Strenght - enemy.Stats.Resistance; 
            if (damage <= 0)
                return;

            var health = enemy.Stats.Health - damage;

            enemy.Stats.SetHealth(health);

            if (enemy.Stats.Health <= 0)
                enemy.IsDead = true;
        }
    }
}
