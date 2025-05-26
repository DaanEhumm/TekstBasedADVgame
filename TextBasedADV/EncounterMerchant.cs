using System;

namespace TextBasedADV
{
    public class EncounterMerchant : Encounter
    {
        public override string Name => "EncounterMerchant";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Een handelaar biedt je een mysterieus item aan.");
            if (roll >= 8)
            {
                Console.WriteLine("Je koopt een nuttig item.");
                player.AddItem("Geneeskruid");
                return EncounterResult.Item;
            }
            else
            {
                Console.WriteLine("Het item blijkt waardeloos te zijn.");
            }
            return EncounterResult.Continue;
        }
    }
}
