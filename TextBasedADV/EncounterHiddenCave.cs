using System;

namespace TextBasedADV
{
    public class EncounterHiddenCave : Encounter
    {
        public override string Name => "EncounterHiddenCave";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Je vindt een verborgen grot.");
            if (roll >= 10)
            {
                Console.WriteLine("Je vindt rust en voedsel in de grot.");
                player.Health.Heal(20);
            }
            else
            {
                Console.WriteLine("De grot is niet veilig... een val struikelt je.");
                player.Health.TakeDamage(15);
                if (player.Health.IsDead) return EncounterResult.Death;
            }
            return EncounterResult.Continue;
        }
    }
}
