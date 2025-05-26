using System;

namespace TextBasedADV
{
    public class BeginEncounter : Encounter
    {
        public override string Name => "BeginEncounter";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Je begint je avontuur. In de verte brandt een dorp... je besluit richting het woud te gaan.");
            gameState.EncounterNumber++;
            return EncounterResult.Continue;
        }
    }
}
