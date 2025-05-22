using System;

namespace TextBasedADV
{
    internal class EncounterRavine : Encounter
    {
        public override string Name => "EncounterRavine";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Je komt een ravijn tegen. Je moet springen om verder te gaan...");
            if (roll <= 5)
            {
                Console.WriteLine("Je valt! Je raakt zwaar gewond.");
                player.Health.TakeDamage(30);
                if (player.Health.IsDead) return EncounterResult.Death;
            }
            else
            {
                Console.WriteLine("Je springt behendig naar de overkant.");
            }
            return EncounterResult.Continue;
        }
    }
}