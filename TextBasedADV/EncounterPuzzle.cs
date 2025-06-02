using System;

namespace TextBasedADV
{
    public class EncounterPuzzle : Encounter
    {
        public override string Name => "Het Raadsel";
        protected override string description =>
            "Een mysterieuze figuur verschijnt en biedt je een raadsel aan. Hij beweert dat je er iets waardevols mee kunt winnen.";

        public override EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine("Wat doe je?");
            Console.WriteLine("1. Los het raadsel op.");
            Console.WriteLine("2. Negeer de figuur en loop verder.");

            int choice = 0;
            while (choice != 1 && choice != 2)
            {
                Console.Write("Jouw keuze (1 of 2): ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            if (choice == 1)
            {
                Console.WriteLine("Druk op SPATIE om te dobbelen...");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
                roll = new DobbelSteen().RollWithAnimation();

                if (roll >= 10)
                {
                    string item = player.Class switch
                    {
                        PlayerClass.Wizard => "Oude Magische Steen",
                        PlayerClass.Soldier => "Versterkt Zwaard",
                        PlayerClass.Knight => "Schild van Licht",
                        _ => "Zeldzaam Artefact"
                    };
                    Console.WriteLine($"Je lost het raadsel op en ontvangt: {item}!");
                    player.AddItem(item);
                    gameState.HasSpecialItem = true;
                    return EncounterResult.Item;
                }
                else
                {
                    Console.WriteLine("Je faalt en de figuur verdwijnt zonder iets te geven.");
                }
            }
            else
            {
                Console.WriteLine("Je loopt door zonder je in te laten met het raadsel.");
            }

            return EncounterResult.Continue;
        }
    }
}