using System;
using System.Collections.Generic;
using System.Linq;
using static TextBasedADV.Encounter;

namespace TextBasedADV
{
    public class GameManager
    {
        private Player _player;
        private DobbelSteen _dobbelSteen = new();
        private GameState _gameState = new();
        private List<Encounter> _encounters = new();

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welkom bij het Avontuur!");
            SelectPlayerClass();
            CreateEncounters();

            foreach (var encounter in _encounters)
            {
                Console.WriteLine($"\n--- {encounter.Name} ---");
                encounter.Describe();

                if (encounter is BeginEncounter)
                {
                    encounter.Resolve(0, _player, _gameState);
                }
                else
                {
                    Console.WriteLine("\nDruk op SPATIE om te dobbelen...");
                    while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

                    int roll = _dobbelSteen.RollWithAnimation();
                    var result = encounter.Resolve(roll, _player, _gameState);

                    if (result == EncounterResult.Death)
                    {
                        Console.WriteLine("Je bent gestorven. Game over.");
                        EndingHandler.ShowEnding(_player, _gameState);
                        return;
                    }
                }

                Console.WriteLine("\n--- Volgend encounter start binnenkort... ---");
                Thread.Sleep(3000);
            }

            EndingHandler.ShowEnding(_player, _gameState);
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
            _encounters.Add(new BeginEncounter());

            var middleEncounters = new List<Encounter>
            {
                new EncounterPuzzle(),
                new EncounterRavine(),
                new EncounterHealer(),
                new EncounterBandits(),
                new EncounterMerchant(),
                new EncounterSplitPath(),
                new EncounterHiddenCave(),
                new EncounterOldTemple(),
                new EncounterWildBeast()
            };

            var random = new Random();
            var selected = middleEncounters.OrderBy(x => random.Next()).Take(4).ToList();
            _encounters.AddRange(selected);
            _encounters.Add(new FinalBossEncounter());
        }
    }
}