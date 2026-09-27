using System;

namespace MiniRPG
{
    // Handles the player-specific abilities and items
    class Player : Character
    {
        public int HealthPotions { get; set; }
        public int ManaPotions { get; set; }
        public int PowerupPotions { get; set; }

        public Player(string name)
            : base(name, 100, 50, 15, 5)
        {
            HealthPotions = 3;
            ManaPotions = 2;
            PowerupPotions = 1;
        }

        // Restores health using a health potion
        public void Heal()
        {
            if (HealthPotions > 0)
            {
                int oldHealth = Health;

                Health += 30;

                if (Health > MaxHealth)
                {
                    Health = MaxHealth;
                }

                HealthPotions--;

                Console.WriteLine(
                    $"{Name} used a health potion and restored " +
                    $"{Health - oldHealth} health."
                );
            }
            else
            {
                Console.WriteLine("You don't have any health potions!");
            }
        }

        // Restores mana using a mana potion
        public void RestoreMana()
        {
            if (ManaPotions > 0)
            {
                int oldMana = Mana;

                Mana += 25;

                if (Mana > MaxMana)
                {
                    Mana = MaxMana;
                }

                ManaPotions--;

                Console.WriteLine(
                    $"{Name} restored {Mana - oldMana} mana."
                );
            }
            else
            {
                Console.WriteLine("You don't have any mana potions!");
            }
        }

        // Increases the player's attack power
        public void UsePowerupPotion()
        {
            if (PowerupPotions > 0)
            {
                AttackPower += 5;
                PowerupPotions--;

                Console.WriteLine(
                    $"{Name}'s attack power increased by 5!"
                );
            }
            else
            {
                Console.WriteLine("You don't have any power-up potions!");
            }
        }

        // Uses mana to cast a spell against an enemy
        public void CastFreezeRay(Character target)
        {
            int manaCost = 15;

            if (Mana >= manaCost)
            {
                Mana -= manaCost;

                int damage = 20;

                Console.WriteLine(
                    $"{Name} casts Freeze Ray on {target.Name}!"
                );

                target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine("You don't have enough mana!");
            }
        }
    }
}