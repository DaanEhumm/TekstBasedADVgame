using System;

namespace TextBasedADV
{
    public class EncounterOldTemple : Encounter
    {
        public override string Name => "De Oude Tempel";
        protected override string description =>
            "Je betreedt een eeuwenoude tempel. Binnen loert het gevaar én glanst een schat.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat doe je?");
            Console.WriteLine("1. Onderzoek de tempel.");
            Console.WriteLine("2. Blijf buiten en ga verder.");

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
                if (roll >= 11)
                {
                    Console.WriteLine("Je vindt een Tempelschat zonder kleerscheuren.");
                    player.AddItem("Tempelschat");
                    return EncounterResult.Item;
                }
                else
                {
                    Console.WriteLine("Je trapt in een val en raakt gewond.");
                    player.Health.TakeDamage(25);
                    if (player.Health.IsDead) return EncounterResult.Death;
                }
            }
            else
            {
                Console.WriteLine("Je vermijdt het risico en trekt verder.");
            }

            return EncounterResult.Continue;
        }
    }
}



