using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedADV
{
    internal class EncounterSplitPath : Encounter
    {
        public override string Name => "EncounterSplitPath";
        public override void Describe()
        {
            Console.WriteLine("Je staat voor een splitsing in het pad. Links leidt naar een donker bos, rechts naar een bergpad.");
        }
        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {

            int choice = 0;
            while (choice != 1 && choice != 2)
            {
                Console.Write("Wat kies je? (1 = bos, 2 = berg): ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            Encounter NextEncounter = choice == 1
                ? new EncounterWildBeast()
                : new EncounterOldTemple();

            Console.WriteLine($"Je gaat {(choice == 1 ? "het bos" : "het bergpad")} op...");
            return NextEncounter.Resolve(roll, player, gameState);
        }
    }
}
