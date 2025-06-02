using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TextBasedADV
{
    public class GameManager
    {
        private Player _player;
        private GameState _gameState = new();
        private List<Encounter> _encounters = new();

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welkom bij het Avontuur!");
            Console.WriteLine("Er gaan geruchten over een draak die dorpen verbrandt...");
            Console.WriteLine("Jij wordt gestuurd om dit gevaar te onderzoeken en – als je durft – te stoppen.");
            Thread.Sleep(4500);

            SelectPlayerClass();
            CreateEncounters();

            foreach (var encounter in _encounters)
            {
                Console.Clear();
                Console.WriteLine($"\n--- {encounter.Name} ---");
                encounter.Describe();

                EncounterResult result = encounter.Resolve(0, _player, _gameState);

                if (result == EncounterResult.Death)
                {
                    Console.WriteLine("\nJe bent gestorven. Game over.");
                    return;
                }

                if (encounter is FinalBossEncounter)
                {
                    return;
                }

                Console.WriteLine("\n--- Volgend encounter start binnenkort... ---");
                Thread.Sleep(3000);
            }

            Console.WriteLine("\nJe hebt alle encounters doorstaan, maar de draak is ontsnapt...");
            Console.WriteLine("Het land leeft in angst. Misschien krijg je een tweede kans.");
            Console.WriteLine("\nBedankt voor het spelen!");
        }

        private void SelectPlayerClass()
        {
            Console.Clear();
            Console.WriteLine("Kies een heldenklasse die je op deze missie stuurt:");
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
            Thread.Sleep(1500);
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
                new EncounterOldTemple(),
                new EncounterWildBeast(),
                new EncounterCursedLake(),
                new EncounterTrial(),
            };

            var random = new Random();
            var selected = middleEncounters.OrderBy(x => random.Next()).Take(7).ToList();
            _encounters.AddRange(selected);

            _encounters.Add(new FinalBossEncounter());
        }
    }
}