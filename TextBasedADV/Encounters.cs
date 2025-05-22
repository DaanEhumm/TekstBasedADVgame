using System;

namespace TextBasedADV
{ 
    internal class Encounter
    {
        private int _number;

        internal Encounter(int number)
        {
            _number = number;
        }
    
        internal enum EncounterResult
        {
            Continue,
            Heal,
            Damage,
            Item,
            Death
        }
    

    internal EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine($"\n--- Encounter {gameState.EncounterNumber} ---");

            switch (gameState.EncounterNumber)
            {
                case 1:
                    Console.WriteLine("Je begint je avontuur. In de verte brandt een dorp... je besluit richting het woud te gaan.");
                    break;

                case 2:
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
                    break;

                case 3:
                    Console.WriteLine("Je komt een ravijn tegen. Je moet springen om verder te gaan...");
                    if (roll <= 5)
                    {
                        Console.WriteLine("Je valt! Je raakt zwaar gewond.");
                        player.Health.TakeDamage(30);
                        if (player.Health.IsDead) return EncounterResult.Death;
                    }
                    else
                    {
                        Console.WriteLine("Je springt behendig naar de overkant.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Een genezer biedt hulp aan.");
                    if (roll >= 8)
                    {
                        Console.WriteLine("Je wordt geheeld.");
                        player.Health.Heal(40);
                    }
                    else
                    {
                        Console.WriteLine("De genezer is een oplichter en steelt van je!");
                        player.Health.TakeDamage(10);
                        if (player.Health.IsDead) return EncounterResult.Death;
                    }
                    break;

                case 5:
                    Console.WriteLine("Je hoort gebrul in de verte. De draak is dichtbij...");
                    Console.WriteLine("Je bereidt je voor op het eindgevecht.");
                    break;

                case 6:
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

            gameState.EncounterNumber++;
            return EncounterResult.Continue;
        }
    }
}