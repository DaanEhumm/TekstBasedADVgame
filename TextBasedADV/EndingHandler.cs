using System;

namespace TextBasedADV
{
    public static class EndingHandler
    {
        public static void ShowEnding(Player player, GameState gameState)
        {
            Console.Clear();
            Console.WriteLine("--- EINDE VAN JE AVONTUUR ---\n");

            if (player.Health.IsDead)
            {
                Console.WriteLine("Je bent gestorven tijdens je zoektocht.");
            }
            else if (gameState.PlayerWon)
            {
                string klasseString = player.Class switch
                {
                    PlayerClass.Wizard => "magische",
                    PlayerClass.Knight => "eervolle",
                    PlayerClass.Soldier => "dappere",
                    _ => "onbekende"
                };

                Console.WriteLine($"Met je {klasseString} vaardigheden en het speciale artefact, versloeg je de draak!");
                Console.WriteLine("Het koninkrijk is gered. Jouw naam zal eeuwenlang herinnerd worden!");
            }
            else
            {
                Console.WriteLine("Je hebt de draak niet kunnen verslaan...");
                Console.WriteLine("Het land blijft in duisternis gehuld.");
            }

            Console.WriteLine("\nBedankt voor het spelen!");
        }
    }
}

