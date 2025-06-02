using System;

namespace TextBasedADV
{
    public class EncounterRavine : Encounter
    {
        public override string Name => "Ravijn";
        protected override string description => "Je komt een ravijn tegen. Wat doe je?";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Maak je keuze:");
            Console.WriteLine("1. Je probeert te springen.");
            Console.WriteLine("2. Je loopt om.");

            int keuze = 0;
            while (keuze != 1 && keuze != 2)
            {
                Console.Write("Jouw keuze (1/2): ");
                int.TryParse(Console.ReadLine(), out keuze);
            }

            Console.WriteLine("\nDruk op SPATIE om te dobbelen...");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            var dobbelSteen = new DobbelSteen();
            int rollResult = dobbelSteen.RollWithAnimation();

            if (keuze == 1)
            {
                if (rollResult <= 5)
                {
                    Console.WriteLine("Je valt! Je raakt zwaar gewond.");
                    player.Health.TakeDamage(30);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
                else
                {
                    Console.WriteLine("Je springt behendig naar de overkant.");
                }
            }
            else
            {
                Console.WriteLine("Je kiest voor de veilige route en loopt om het ravijn heen.");
            }

            return EncounterResult.Continue;
        }
    }
}