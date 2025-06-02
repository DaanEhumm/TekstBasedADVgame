using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace TextBasedADV
{
    public class EncounterTrial : Encounter
    {
        public override string Name => "De Heilige Beproeving";
        protected override string description =>
            "Je betreedt een verborgen heiligdom, waar een mystieke kracht jouw ware aard op de proef stelt...";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Een stem galmt: 'Alleen zij die waardig zijn, zullen het Artefact ontvangen...'");
            Thread.Sleep(1500);

            Console.WriteLine("Wil je de beproeving aangaan?");
            Console.WriteLine("1. Ja, ik ben klaar.");
            Console.WriteLine("2. Nee, ik wil doorgaan zonder risico.");

            int choice = 0;
            while (choice != 1 && choice != 2)
            {
                Console.Write("Jouw keuze (1 of 2): ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            if (choice == 2)
            {
                Console.WriteLine("Je verlaat het heiligdom zonder iets aan te raken.");
                return EncounterResult.Continue;
            }

            Console.WriteLine("Druk op SPATIE om te dobbelen voor je beproeving...");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
            roll = new DobbelSteen().RollWithAnimation();

            string itemName = player.Class switch
            {
                PlayerClass.Wizard => "Oude Magische Steen",
                PlayerClass.Soldier => "Versterkt Zwaard",
                PlayerClass.Knight => "Helm van Licht",
                _ => "Onbekend Artefact"
            };

            int requiredRoll = player.Class switch
            {
                PlayerClass.Wizard => 9,
                PlayerClass.Soldier => 8,
                PlayerClass.Knight => 10,
                _ => 12
            };

            if (roll >= requiredRoll)
            {
                Console.WriteLine($"\nJe hebt de proef doorstaan! Je ontvangt het Artefact: {itemName}");
                player.AddItem(itemName);
                return EncounterResult.Item;
            }
            else
            {
                Console.WriteLine("\nDe kracht wijst je af. Je wordt verwond door een magische schok.");
                player.Health.TakeDamage(20);
                if (player.Health.IsDead) return EncounterResult.Death;
            }

            return EncounterResult.Continue;
        }
    }
}
