using System;
using System.Collections.Generic;

namespace TextBasedADV
{
    internal class GameManager
    {
        private Player _player;
        private readonly List<Encounter> _encounters = new();
        private readonly DobbelSteen _dobbelSteen = new();
        private readonly GameState _gameState = new();

        internal void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welkom bij het Avontuur!");
            SelectPlayerClass();
            CreateEncounters();

            foreach (var encounter in _encounters)
            {
                Console.WriteLine("\nDruk op SPATIE om te dobbelen...");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

                int roll = _dobbelSteen.Roll();
                Console.WriteLine($"Je rolde een {roll}!");

                var result = encounter.Resolve(roll, _player, _gameState);

                if (result == EncounterResult.Death)
                {
                    Console.WriteLine("Je bent gestorven. Game over.");
                    EndingHandler.ShowEnding(_player);
                    return;
                }
            }

            EndingHandler.ShowEnding(_player);
        }

        private void SelectPlayerClass()
        {
            Console.WriteLine("Kies een class:");
            var classes = Enum.GetValues(typeof(PlayerClass));
            int index = 1;
            foreach (var c in classes)
            {
                Console.WriteLine($"{index}. {c}");
                index++;
            }

            int keuze = 0;
            while (keuze < 1 || keuze > classes.Length)
            {
                Console.Write("Jouw keuze: ");
                int.TryParse(Console.ReadLine(), out keuze);
            }

            _player = new Player((PlayerClass)(keuze - 1));
            Console.WriteLine($"Je koos: {_player.Class}");
        }

        private void CreateEncounters()
        {
            for (int i = 0; i < 6; i++)
            {
                _encounters.Add(new Encounter(i + 1));
            }
        }
    }
}

