using System;

namespace TextBasedADV
{
    public class EncounterCursedLake : Encounter
    {
        public override string Name => "Het Vervloekte Meer";
        protected override string description =>
            "Je staat voor een donker meer waaruit een object schijnt te glinsteren.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat doe je?");
            Console.WriteLine("1. Probeer het object uit het water te halen.");
            Console.WriteLine("2. Loop om het meer heen.");

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
                    Console.WriteLine("Je grijpt het Magisch Wateramulet!");
                    player.AddItem("Magisch Wateramulet");
                    return EncounterResult.Item;
                }
                else
                {
                    Console.WriteLine("Het water grijpt je! Je raakt verwond.");
                    player.Health.TakeDamage(20);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
            }
            else
            {
                Console.WriteLine("Je vermijdt het risico en kiest de veilige route.");
            }

            return EncounterResult.Continue;
        }
    }
}