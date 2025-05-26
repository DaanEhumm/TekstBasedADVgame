using System;

namespace TextBasedADV
{
    public class EncounterMerchant : Encounter
    {
        public override string Name => "EncounterMerchant";

        protected override string description => "Een handelaar biedt je een mysterieus item aan."; // gaat hierom 


        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
        
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


////// dit is het script dat nagemaakt moet worden bij alle Encounters andere scripten 