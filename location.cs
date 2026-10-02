using System;

namespace MiniRPG
{
    // Contains the locations and secret areas in the game
    class Locations
    {
        public static string[] Areas =
        {
            "Forest",
            "Graveyard",
            "Cave",
            "Ruins",
            "Dragon's Lair"
        };

        public static string[] SecretAreas =
        {
            "Hidden Treasure Room",
            "Hidden Tower",
            "Secret Room"
        };

        public static void ShowLocations()
        {
            Console.WriteLine();
            Console.WriteLine("Available Areas:");

            for (int i = 0; i < Areas.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Areas[i]}");
            }
        }

        public static string GetRandomArea(Random random)
        {
            int number = random.Next(Areas.Length);
            return Areas[number];
        }

        public static string GetRandomSecretArea(Random random)
        {
            int number = random.Next(SecretAreas.Length);
            return SecretAreas[number];
        }
    }
}