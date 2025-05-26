using System;

namespace TextBasedADV
{
    public class EncounterBandits : Encounter
    {
        public override string Name => "EncounterBandits";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Bandieten vallen je aan!");
            if (roll >= 10)
            {
                Console.WriteLine("Je verslaat de bandieten en vindt een klein beetje goud.");
            }
            else
            {
                Console.WriteLine("De bandieten overmeesteren je en je raakt gewond.");
                player.Health.TakeDamage(20);
                if (player.Health.IsDead) return EncounterResult.Death;
            }
            return EncounterResult.Continue;
        }
    }
