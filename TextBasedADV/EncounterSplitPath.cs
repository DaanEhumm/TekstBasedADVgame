using System;

namespace TextBasedADV
{
    public class EncounterSplitPath : Encounter
    {
        public override string Name => "Het Gesplitste Pad";
        protected override string description =>
            "Het pad splitst zich: het ene leidt het bos in, het andere richting een ruïneuze tempel in de bergen.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat kies je?");
            Console.WriteLine("1. Ga het bos in.");
            Console.WriteLine("2. Kies het bergpad naar de oude tempel.");

            int choice = 0;
            while (choice != 1 && choice != 2)
            {
                Console.Write("Jouw keuze (1 of 2): ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            Console.WriteLine("Druk op SPATIE om te dobbelen...");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
            roll = new DobbelSteen().RollWithAnimation();

            Encounter next = choice == 1
                ? new EncounterWildBeast()
                : new EncounterOldTemple();

            return next.Resolve(roll, player, gameState);
        }
    }
}