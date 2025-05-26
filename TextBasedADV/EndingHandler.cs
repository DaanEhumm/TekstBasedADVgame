using System;

namespace TextBasedADV
{
    public static class EndingHandler
    {
        public static void ShowEnding(Player player, GameState gameState)
        {
            Console.WriteLine("\n--- EINDE ---");
            if (player.Health.IsDead)
            {
                Console.WriteLine("Je bent gestorven tijdens je avontuur.");
            }
            else if (gameState.PlayerWon)
            {
                Console.WriteLine($"Je hebt de draak verslagen met jouw {player.Class}-kracht. Je bent een legende!");
            }
            else
            {
                Console.WriteLine("Je hebt het einde bereikt... maar niet overwonnen.");
            }
        }
    }

}

