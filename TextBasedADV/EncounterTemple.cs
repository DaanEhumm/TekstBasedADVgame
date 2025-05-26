using System;

namespace TextBasedADV
{
    public class EncounterOldTemple : Encounter
    {
        public override string Name => "EncounterOldTemple";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Je ontdekt een verlaten tempel vol valstrikken.");
            if (roll >= 11)
            {
                Console.WriteLine("Je ontwijkt de valstrikken en vindt een waardevol artefact.");
                player.AddItem("Tempelschat");
            }
            else
            {
                Console.WriteLine("Je trapt in een val en raakt gewond.");
                player.Health.TakeDamage(25);
                if (player.Health.IsDead) return EncounterResult.Death;
            }
            return EncounterResult.Continue;
        }
    }
}
