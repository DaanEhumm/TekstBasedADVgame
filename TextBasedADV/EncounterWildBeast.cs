using System;

namespace TextBasedADV
{
    public class EncounterWildBeast : Encounter
    {
        public override string Name => "EncounterWildBeast";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Een wild beest stormt op je af!");
            if (roll >= 9)
            {
                Console.WriteLine("Je verslaat het beest met moeite.");
            }
            else
            {
                Console.WriteLine("Het beest verwondt je zwaar.");
                player.Health.TakeDamage(35);
                if (player.Health.IsDead) return EncounterResult.Death;
            }
            return EncounterResult.Continue;
        }
    }
}