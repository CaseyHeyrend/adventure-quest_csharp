using System;

namespace MiniRPG
{
    // Base class for characters in the game
    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        public Character(string name, int health, int mana, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Mana = mana;
            MaxMana = mana;
            AttackPower = attackPower;
            Defense = defense;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void TakeDamage(int rawDamage)
        {
            int damage = Math.Max(1, rawDamage - Defense);

            Health -= damage;

            if (Health < 0)
            {
                Health = 0;
            }

            int blocked = Math.Min(rawDamage - 1, Defense);

            Console.WriteLine(
                $"{Name} takes {damage} damage! " +
                $"Blocked {blocked}. " +
                $"Health: {Health}/{MaxHealth}"
            );
        }
    }
}