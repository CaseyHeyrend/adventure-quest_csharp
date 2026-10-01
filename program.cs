using System;

namespace MiniRPG
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.Title = "Adventure Quest";

            Console.WriteLine("==============================");
            Console.WriteLine("        ADVENTURE QUEST");
            Console.WriteLine("==============================");
            Console.WriteLine();

            // Create the player's character
            Console.Write("Enter your character name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine();
            Console.WriteLine("Choose your class:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Knight");
            Console.WriteLine("3. Mage");
            Console.WriteLine("4. Archer");
            Console.WriteLine("5. Rogue");

            Console.Write("Enter your choice: ");
            string classChoice = Console.ReadLine() ?? string.Empty;

            // Make sure the player chooses a valid class
            while (classChoice != "1" &&
                   classChoice != "2" &&
                   classChoice != "3" &&
                   classChoice != "4" &&
                   classChoice != "5")
            {
                Console.WriteLine("Please choose a class from 1-5.");
                Console.Write("Enter your choice: ");
                classChoice = Console.ReadLine() ?? string.Empty;
            }

            Player player = new Player(name, classChoice);

            Console.WriteLine();
            Console.WriteLine($"Welcome, {player.Name} the {player.ClassName}!");
            Console.WriteLine($"Your starting weapon is the {player.Weapon}.");
            Console.WriteLine("Your adventure is about to begin.");
            Console.WriteLine();

            GameLoop(player);
        }

        // Main game loop
        static void GameLoop(Player player)
        {
            bool playing = true;

            while (playing && player.IsAlive())
            {
                Console.WriteLine();
                Console.WriteLine("========== MAIN MENU ==========");
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. View Stats");
                Console.WriteLine("3. Use Potion");
                Console.WriteLine("4. Quit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        Explore(player);
                        break;

                    case "2":
                        DisplayStats(player);
                        break;

                    case "3":
                        UsePotion(player);
                        break;

                    case "4":
                        playing = false;
                        Console.WriteLine("Thanks for playing Adventure Quest!");
                        break;

                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }

            if (!player.IsAlive())
            {
                Console.WriteLine();
                Console.WriteLine("You have been defeated!");
                Console.WriteLine("Game Over.");
            }
        }

        // Allows the player to explore different locations
        static void Explore(Player player)
        {
            string location = Locations.GetRandomArea(random);

            Console.WriteLine();
            Console.WriteLine($"You travel to the {location}.");
            Console.WriteLine();

            int eventNumber = random.Next(1, 5);

            if (eventNumber == 1)
            {
                FindSecretArea(player);
            }
            else if (eventNumber == 2)
            {
                Console.WriteLine("The area is quiet.");
                Console.WriteLine("You find nothing unusual.");
            }
            else
            {
                Character enemy = CreateRandomEnemy();

                Console.WriteLine($"A {enemy.Name} appears!");
                Combat(player, enemy);
            }
        }

        // Gives the player a chance to discover a secret area
        static void FindSecretArea(Player player)
        {
            string secret = Locations.GetRandomSecretArea(random);

            Console.WriteLine("You notice something hidden nearby!");
            Console.WriteLine($"You discovered the {secret}!");
            Console.WriteLine();

            int reward = random.Next(1, 4);

            if (reward == 1)
            {
                player.Health += 20;

                if (player.Health > player.MaxHealth)
                {
                    player.Health = player.MaxHealth;
                }

                Console.WriteLine("You found a healing item.");
                Console.WriteLine("You recovered some health.");
            }
            else if (reward == 2)
            {
                player.HealthPotions++;

                Console.WriteLine("You found a health potion!");
            }
            else
            {
                player.PowerupPotions++;

                Console.WriteLine("You found a power-up potion!");
            }
        }

        // Creates a random enemy
        static Character CreateRandomEnemy()
        {
            int enemyNumber = random.Next(1, 5);

            switch (enemyNumber)
            {
                case 1:
                    return new PumpkinHead();

                case 2:
                    return new HauntedTree();

                case 3:
                    return new AngrySkeleton();

                default:
                    return new FireDragon();
            }
        }

        // Displays the player's current information
        static void DisplayStats(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("========== STATS ==========");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Class: {player.ClassName}");
            Console.WriteLine($"Weapon: {player.Weapon}");
            Console.WriteLine($"Weapon Bonus: +{player.WeaponBonus}");
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Mana: {player.Mana}/{player.MaxMana}");
            Console.WriteLine($"Attack: {player.AttackPower}");
            Console.WriteLine($"Defense: {player.Defense}");
            Console.WriteLine($"Health Potions: {player.HealthPotions}");
            Console.WriteLine($"Mana Potions: {player.ManaPotions}");
            Console.WriteLine($"Power-up Potions: {player.PowerupPotions}");
        }

        // Allows the player to choose a potion
        static void UsePotion(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("========== POTIONS ==========");
            Console.WriteLine("1. Health Potion");
            Console.WriteLine("2. Mana Potion");
            Console.WriteLine("3. Power-up Potion");
            Console.WriteLine("4. Back");

            Console.Write("Choose a potion: ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    player.Heal();
                    break;

                case "2":
                    player.RestoreMana();
                    break;

                case "3":
                    player.UsePowerupPotion();
                    break;

                case "4":
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        // Handles a battle between the player and an enemy
        static void Combat(Player player, Character enemy)
        {
            while (player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine($"{player.Name}: {player.Health} HP");
                Console.WriteLine($"{enemy.Name}: {enemy.Health} HP");
                Console.WriteLine("==============================");

                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Freeze Ray");
                Console.WriteLine("3. Potion");
                Console.WriteLine("4. Run");

                Console.Write("Choose an action: ");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        PlayerAttack(player, enemy);
                        break;

                    case "2":
                        player.CastFreezeRay(enemy);
                        break;

                    case "3":
                        UsePotion(player);
                        break;

                    case "4":
                        Console.WriteLine("You ran away!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                // Enemy attacks if it is still alive
                if (enemy.IsAlive())
                {
                    EnemyAttack(player, enemy);
                }
            }

            if (player.IsAlive())
            {
                Console.WriteLine();
                Console.WriteLine($"You defeated the {enemy.Name}!");
            }
        }

        // Handles the player's normal attack
        static void PlayerAttack(Player player, Character enemy)
        {
            Console.WriteLine();
            Console.WriteLine($"{player.Name} attacks {enemy.Name}!");

            int damage = player.AttackPower + player.WeaponBonus;

            Console.WriteLine(
                $"You deal {damage} damage using your {player.Weapon}!"
            );

            enemy.TakeDamage(damage);
        }

        // Handles an enemy attacking the player
        static void EnemyAttack(Player player, Character enemy)
        {
            Console.WriteLine();
            Console.WriteLine($"{enemy.Name} attacks!");

            player.TakeDamage(enemy.AttackPower);
        }
    }
}