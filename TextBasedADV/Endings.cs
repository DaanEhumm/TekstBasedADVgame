using System;
using System;

namespace TextBasedADV
{
    internal static class EndingHandler
    {
        internal static void ShowEnding(Player player)
        {
            Console.WriteLine("\n--- EINDE ---");
            if (player.Health.IsDead)
            {
                Console.WriteLine("Je bent gestorven in je avontuur.");
            }
            else if (player.HasItem("Oude Magische Steen") || player.HasItem("Versterkt Zwaard"))
            {
                Console.WriteLine("Je gebruikte je kracht om de draak te verslaan. Je bent een held!");
            }
            else
            {
                Console.WriteLine("Je overleefde, maar de draak liet een spoor van vernietiging achter...");
            }
        }
    }
}

