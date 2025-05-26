using System;

namespace TextBasedADV
{
    public class EncounterOldTemple : Encounter
    {
        public override string Name => "EncounterOldTemple";
        public override void Describe()
        {
            Console.WriteLine("Je komt aan bij een oude tempel, omgeven door dichte jungle. De ingang is bedekt met klimop en lijkt lang niet bezocht te zijn.");
        }
        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
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
