using System;

namespace TextBasedADV
{
    public class EncounterHealer : Encounter
    {
        public override string Name => "De Genezer";
        protected override string description => "Je komt een oude vrouw tegen die zich voorstelt als genezeres. Ze biedt je aan je wonden te verzorgen.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat doe je?");
            Console.WriteLine("1. Laat je verzorgen.");
            Console.WriteLine("2. Wantrouw haar en ga verder.");

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
                if (roll >= 7)
                {
                    Console.WriteLine("Ze geneest je wonden met kruiden.");
                    player.Health.Heal(40);
                    return EncounterResult.Heal;
                }
                else
                {
                    Console.WriteLine("Ze blijkt een dief te zijn en verwondt je!");
                    player.Health.TakeDamage(15);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
            }
            else
            {
                Console.WriteLine("Je besluit haar niet te vertrouwen en gaat verder.");
            }

            return EncounterResult.Continue;
        }
    }
}