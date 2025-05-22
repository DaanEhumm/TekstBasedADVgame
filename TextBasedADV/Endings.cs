using System;

namespace TextBasedADV
{
    internal static class EndingHandler
    {
        internal static void ShowEnding(Player player, GameState gameState)
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
                Console.WriteLine("Je bent verbrand door de draak");
            }
        }
    }
}

