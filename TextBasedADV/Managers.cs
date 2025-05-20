using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedADV
{
    internal class GameManager
    {
        private Player _player;
        private readonly List<Encounter> encounters = new();
        private readonly DobbelSteen dobbelSteen = new();

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welkom bij het Avontuur!");
            SelectPlayerClass();
            CreateEncounters();

            foreach (var encounter in encounters)
            {
                Console.WriteLine("\nDruk op spatie om te dobbelen...");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

                int roll = dobbelSteen.Roll();
                Console.WriteLine($"Je rolde een {roll}!");
                var result = encounter.Resolve(roll, _player);

                if (result == EncounterResult.Death)
                {
                    Console.WriteLine("Je bent overleden! Het spel is voorbij.");
                    return;
                }
            }

            EndingHandler.ShowEnding(_player);
        }

        private void SelectPlayerClass()
        {
            Console.WriteLine("Kies je class:");
            var classes = Enum.GetValues(typeof(PlayerClass));
            int index = 1;
            foreach (var c in classes)
            {
                Console.WriteLine($"{index}. {c}");
                index++;
            }

            int choice = 0;
            while (choice < 1 || choice > classes.Length)
            {
                Console.Write("Jouw keuze: ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            _player = new Player((PlayerClass)(choice - 1));
            Console.WriteLine($"Je koos: {_player.Class}");
        }

        private void CreateEncounters()
        {
            for (int i = 0; i < 5; i++)
            {
                encounters.Add(new Encounter(i + 1));
            }
        }
    }
}

