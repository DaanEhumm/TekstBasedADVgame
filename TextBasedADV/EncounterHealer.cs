using System;

namespace TextBasedADV
{
    public class EncounterHealer : Encounter
    {
        public override string Name => "EncounterHealer";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Een genezer biedt hulp aan.");
            if (roll >= 8)
            {
                Console.WriteLine("Je wordt geheeld.");
                player.Health.Heal(40);
                return EncounterResult.Heal;
            }
            else
            {
                Console.WriteLine("De genezer is een oplichter en steelt van je!");
                player.Health.TakeDamage(10);
                if (player.Health.IsDead) return EncounterResult.Death;
            }
            return EncounterResult.Continue;
        }
    }
}