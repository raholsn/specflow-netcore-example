using System;

namespace Domain
{
    public class Stats
    {
        public Guid Id { get; }
        public int Strenght { get; }
        public int Dexterity { get;  }
        public int Stamina { get;  }

        public int Resistance { get; private set; }
        public double Health { get; private set; }

        public Stats(int strength,int dexterity,  RaceEnum race, double health = 100)
        {
            Id = Guid.NewGuid();
            Strenght = strength;
            Dexterity = dexterity;
            Health = health;

            SetResistance(race);
        }

        public void SetResistance(RaceEnum race)
        {
            if (race.IsElf())
                Resistance = 20;
            if (race.IsOrc())
                Resistance = 10;
        }

        public void SetHealth(double health) {
            this.Health = health;
        }
    }
}