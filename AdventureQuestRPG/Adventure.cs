using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class Adventure
    {
        private Player player;
        private List<Monster> monsters;
        private List<string> locations;
        private string currentLocation;

        public Adventure(Player player)
        {
            this.player = player;
            InitializeMonsters();
            InitializeLocations();
            currentLocation = locations[0];
        }

        private void InitializeMonsters()
        {
            monsters = new List<Monster>
            {
                new Dragon("Dragon", 200, 30, 15),
                new Goblin("Goblin", 50, 10, 5),
                new Zombie("Zombie", 100, 20, 10),
                new BossMonster("Boss Dragon", 500, 50, 25)
            };
        }

        private void InitializeLocations()
        {
            locations = new List<string>
            {
                "Town",
                "Forest",
                "Cave"
            };
        }

        public void Start()
        {
            while (true)
            {
                DisplayCurrentLocation();
                DisplayActions();
                string choice = GetPlayerChoice();

                switch (choice)
                {
                    case "1":
                        MoveToNewLocation();
                        break;
                    case "2":
                        EncounterMonster();
                        break;
                    case "3":
                        Console.WriteLine("Ending the game.");
                        return;
                }
            }
        }

        private void DisplayCurrentLocation()
        {
            Console.WriteLine($"Current Location: {currentLocation}");
        }

        private void DisplayActions()
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Move to a new location");
            Console.WriteLine("2. Encounter a monster");
            Console.WriteLine("3. End the game");
        }

        private string GetPlayerChoice()
        {
            return Console.ReadLine();
        }

        private void MoveToNewLocation()
        {
            Console.WriteLine("Available locations:");
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {locations[i]}");
            }

            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < locations.Count)
            {
                currentLocation = locations[choice];
            }
            else
            {
                Console.WriteLine("Invalid choice. Staying in current location.");
            }
        }

        private void EncounterMonster()
        {
            Random rand = new Random();
            Monster monster = GetRandomMonster();
            Console.WriteLine($"A wild {monster.Name} appears!");

            BattleSystem.StartBattle(player, monster);

            if (player.Health > 0)
            {
                Console.WriteLine("Battle is over. Choose your next action.");
            }
            else
            {
                Console.WriteLine("Game over.");
                Environment.Exit(0);
            }
        }

        private Monster GetRandomMonster()
        {
            Random rand = new Random();
            Monster randomMonster = monsters[rand.Next(monsters.Count)];

            // Create a new instance of the selected monster type to ensure a fresh monster
            if (randomMonster is Dragon)
                return new Dragon("Dragon", 200, 30, 15);
            if (randomMonster is Goblin)
                return new Goblin("Goblin", 50, 10, 5);
            if (randomMonster is Zombie)
                return new Zombie("Zombie", 100, 20, 10);
            if (randomMonster is BossMonster)
                return new BossMonster("Boss Dragon", 500, 50, 25);

            // Default case
            return new Goblin("Goblin", 50, 10, 5);
        }
    }
}
