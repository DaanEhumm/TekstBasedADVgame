using System;

namespace TextBasedADV
{
    public class EncounterWildBeast : Encounter
    {
        public override string Name => "Wilde Beest";
        protected override string description =>
            "Een razend wild beest springt uit de struiken! Je moet reageren.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat doe je?");
            Console.WriteLine("1. Vecht terug.");
            Console.WriteLine("2. Probeer te vluchten.");

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
                if (roll >= 9)
                {
                    Console.WriteLine("Je verslaat het beest met moeite.");
                }
                else
                {
                    Console.WriteLine("Je raakt zwaar gewond in het gevecht.");
                    player.Health.TakeDamage(35);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
            }
            else
            {
                if (roll >= 12)
                {
                    Console.WriteLine("Je ontsnapt nipt!");
                }
                else
                {
                    Console.WriteLine("Het beest haalt je in en verwondt je.");
                    player.Health.TakeDamage(25);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
            }

            return EncounterResult.Continue;
        }
    }
}



