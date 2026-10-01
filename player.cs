using System;

namespace MiniRPG
{
    // Handles the player-specific abilities and items
    class Player : Character
    {
        // Player class and weapon
        public string ClassName { get; set; } = string.Empty;
        public string Weapon { get; set; } = string.Empty;
        public int WeaponBonus { get; set; }

        // Player potions
        public int HealthPotions { get; set; }
        public int ManaPotions { get; set; }
        public int PowerupPotions { get; set; }

        // Creates the player
        public Player(string name, string playerClass)
            : base(name, 100, 50, 15, 5)
        {
            HealthPotions = 3;
            ManaPotions = 2;
            PowerupPotions = 1;

            ChooseClass(playerClass);
        }

        // Gives the player stats and starting weapon based on class
        private void ChooseClass(string playerClass)
        {
            switch (playerClass)
            {
                case "1":
                    ClassName = "Warrior";

                    MaxHealth = 120;
                    Health = 120;
                    MaxMana = 20;
                    Mana = 20;
                    AttackPower = 20;
                    Defense = 8;

                    Weapon = "Longsword";
                    WeaponBonus = 6;
                    break;

                case "2":
                    ClassName = "Knight";

                    MaxHealth = 140;
                    Health = 140;
                    MaxMana = 15;
                    Mana = 15;
                    AttackPower = 16;
                    Defense = 12;

                    Weapon = "The Broadsword";
                    WeaponBonus = 7;
                    break;

                case "3":
                    ClassName = "Mage";

                    MaxHealth = 80;
                    Health = 80;
                    MaxMana = 90;
                    Mana = 90;
                    AttackPower = 14;
                    Defense = 3;

                    Weapon = "Mage's Staff";
                    WeaponBonus = 5;
                    break;

                case "4":
                    ClassName = "Archer";

                    MaxHealth = 90;
                    Health = 90;
                    MaxMana = 40;
                    Mana = 40;
                    AttackPower = 19;
                    Defense = 5;

                    Weapon = "The Longbow";
                    WeaponBonus = 6;
                    break;

                case "5":
                    ClassName = "Rogue";

                    MaxHealth = 85;
                    Health = 85;
                    MaxMana = 35;
                    Mana = 35;
                    AttackPower = 22;
                    Defense = 4;

                    Weapon = "Twin Daggers";
                    WeaponBonus = 7;
                    break;
            }
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

                int damage = AttackPower + 10;

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