using System;

namespace TextBasedADV
{
    public class EncounterMerchant : Encounter
    {
        public override string Name => "De Handelaar";
        protected override string description =>
            "Een mysterieuze handelaar biedt je een vreemd object aan. 'Het kan je redding zijn,' zegt hij.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat doe je?");
            Console.WriteLine("1. Koop het item.");
            Console.WriteLine("2. Wantrouw hem en loop door.");

            int choice = 0;
            while (choice != 1 && choice != 2)
            {
                Console.Write("Jouw keuze (1 of 2): ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            if (choice == 1)
            {
                Console.WriteLine("Druk op SPATIE om te dobbelen...");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
                roll = new DobbelSteen().RollWithAnimation();

                if (roll >= 8)
                {
                    Console.WriteLine("Je koopt een nuttig item: Geneeskruid.");
                    player.AddItem("Geneeskruid");
                    return EncounterResult.Item;
                }
                else
                {
                    Console.WriteLine("Het blijkt een waardeloos voorwerp te zijn.");
                }
            }
            else
            {
                Console.WriteLine("Je negeert hem en gaat verder.");
            }

            return EncounterResult.Continue;
        }
    }
}

