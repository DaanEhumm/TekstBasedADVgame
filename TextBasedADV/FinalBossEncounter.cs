using System;

namespace TextBasedADV
{
    public class FinalBossEncounter : Encounter
    {
        public override string Name => "FinalBossEncounter";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("De draak landt voor je met een oorverdovend gebrul!");

            string requiredItem = player.Class switch
            {
                PlayerClass.Wizard => "Oude Magische Steen",
                PlayerClass.Soldier => "Versterkt Zwaard",
                PlayerClass.Knight => "Helm van Licht",
                PlayerClass.Troll => "Brok Helse Steen",
                PlayerClass.Assassin => "Schaduwmes",
                _ => "Zeldzaam Artefact"
            };

            if (player.HasItem(requiredItem))
            {
                Console.WriteLine("Met jouw speciale artefact voer je een epische aanval uit en versla je de draak!");
                gameState.PlayerWon = true;
                return EncounterResult.Continue;
            }
            else
            {
                Console.WriteLine("Je hebt niet de kracht om de draak te verslaan...");
                return EncounterResult.Death;
            }
        }
    }
}
