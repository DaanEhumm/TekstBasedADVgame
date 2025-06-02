using System;

namespace TextBasedADV
{
    public class BeginEncounter : Encounter
    {
        public override string Name => "Het Begin van het Avontuur";
        protected override string description =>
            "Je staat aan de rand van een donker woud. In de verte zie je rook opstijgen...";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Je betreedt het woud, op zoek naar antwoorden.");
            gameState.EncounterNumber++;
            return EncounterResult.Continue;
        }
    }
}
