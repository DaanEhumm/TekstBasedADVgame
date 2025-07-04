﻿using System;

namespace TextBasedADV
{
    public class EncounterBandits : Encounter
    {
        public override string Name => "De Bandieten";
        protected override string description =>
            "Een groep bandieten springt uit de bosjes en eist je spullen op.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat doe je?");
            Console.WriteLine("1. Vecht terug!");
            Console.WriteLine("2. Probeer ze af te kopen of te onderhandelen.");

            int choice = 0;
            while (choice != 1 && choice != 2)
            {
                Console.Write("Jouw keuze (1 of 2): ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            Console.WriteLine("Druk op SPATIE om te dobbelen...");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
            roll = new DobbelSteen().RollWithAnimation();

            if (choice == 1)
            {
                if (roll >= 10)
                {
                    Console.WriteLine("Je verslaat de bandieten moeiteloos en vindt een klein beetje goud.");
                }
                else
                {
                    Console.WriteLine("Je raakt gewond tijdens het gevecht.");
                    player.Health.TakeDamage(20);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
            }
            else
            {
                if (roll >= 9)
                {
                    Console.WriteLine("Ze accepteren je aanbod en laten je gaan.");
                }
                else
                {
                    Console.WriteLine("Ze bespotten je zwakte en vallen alsnog aan.");
                    player.Health.TakeDamage(25);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
            }

            return EncounterResult.Continue;
        }
    }
}