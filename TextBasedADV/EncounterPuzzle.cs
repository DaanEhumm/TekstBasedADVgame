using System;

namespace TextBasedADV
{
    public class EncounterPuzzle : Encounter
    {
        public override string Name => "EncounterPuzzle";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Een mysterieuze figuur biedt je een raadsel aan...");
            if (roll >= 12)
            {
                string item = player.Class switch
                {
                    PlayerClass.Wizard => "Oude Magische Steen",
                    PlayerClass.Soldier => "Versterkt Zwaard",
                    PlayerClass.Knight => "Helm van Licht",
                    PlayerClass.Troll => "Brok Helse Steen",
                    PlayerClass.Assassin => "Schaduwmes",
                    _ => "Zeldzaam Artefact"
                };
                Console.WriteLine($"Je lost het raadsel op en ontvangt: {item}!");
                player.AddItem(item);
                gameState.HasSpecialItem = true;
            }
            else
            {
                Console.WriteLine("Je faalt het raadsel en de figuur verdwijnt.");
            }
            return EncounterResult.Continue;
        }
    }
}