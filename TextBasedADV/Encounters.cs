using System;

namespace TextBasedADV
{
    internal enum EncounterResult
    {
        Continue,
        Heal,
        Damage,
        Item,
        Death
    }

    internal class Encounter
    {
        private int _number;

        internal Encounter(int number)
        {
            _number = number;
        }

        internal EncounterResult Resolve(int roll, Player player, GameState gameState)
        {
            Console.WriteLine($"\n--- Encounter {gameState.EncounterNumber} ---");

            switch (gameState.EncounterNumber)
            {
                case 1:
                    Console.WriteLine("In de verte zie je een dorp in brand staan. Je besluit terug te keren naar het kasteel voor hulp.");
                    Console.WriteLine("Je begint je reis. De lucht is dreigend er hangt een grimmig sfeertje in de lucht...");
                    break;

                case 2:
                    Console.WriteLine("Je komt bij een kruispunt in het bos...");
                    if (roll <= 8)
                    {
                        Console.WriteLine("Je neemt het linkerpad. Je vond een schatkaart!");
                        gameState.HasTreasureMap = true;
                        player.AddItem("Schatkaart");
                    }
                    else
                    {
                        Console.WriteLine("Je neemt het rechterpad... maar struikrovers liggen op de loer!");
                        player.Health.TakeDamage(15);
                        if (player.Health.IsDead) return EncounterResult.Death;
                    }
                    break;

                case 3:
                    if (gameState.HasTreasureMap && !gameState.HasFoundTreasure)
                    {
                        Console.WriteLine("Je volgt de aanwijzingen op de schatkaart...");
                        string item = player.Class switch
                        {
                            PlayerClass.Wizard => "Oude Magische Steen",
                            PlayerClass.Soldier => "Versterkt Zwaard",
                            _ => "Zeldzaam Artefact"
                        };
                        Console.WriteLine($"Na uren zoeken vind je een verborgen {item}!");
                        player.AddItem(item);
                        gameState.HasFoundTreasure = true;
                    }
                    else
                    {
                        Console.WriteLine("Je doolt door een dicht bos. Een wolf valt aan!");
                        player.Health.TakeDamage(20);
                        if (player.Health.IsDead) return EncounterResult.Death;
                    }
                    break;

                case 4:
                    Console.WriteLine("Je ziet een mysterieus verlaten huis langs het pad.");
                    if (roll <= 6)
                    {
                        Console.WriteLine("Je besluit naar binnen te gaan... je vindt een geneesdrank!");
                        if (player.Health.Current < 100)
                        {
                            player.Health.Heal(25);
                        }
                        else
                        {
                            Console.WriteLine("Je bent al op volle gezondheid. Je bewaart de drank voor later.");
                            player.AddItem("Geneesdrank");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Je durft het huis niet te betreden en loopt verder.");
                    }
                    break;

                case 5:
                    Console.WriteLine("In de verte hoor je luid gebrul. De lucht wordt donker...");
                    if (roll <= 8)
                    {
                        Console.WriteLine("Je zoekt dekking en bereidt je voor. De draak is ontwaakt.");
                        gameState.DragonAwakened = true;
                    }
                    else
                    {
                        Console.WriteLine("Je negeert het geluid en loopt door... maar je voelt dat iets niet klopt.");
                        gameState.DragonAwakened = true;
                        player.Health.TakeDamage(10);
                        if (player.Health.IsDead) return EncounterResult.Death;
                    }
                    break;

                case 6:
                    Console.WriteLine("De draak nadert snel! De lucht trilt van zijn gebrul!");
                    if (gameState.DragonAwakened)
                    {
                        if (player.HasItem("Versterkt Zwaard") || player.HasItem("Oude Magische Steen"))
                        {
                            Console.WriteLine("Je gebruikt je gevonden kracht om de draak te verslaan in een episch gevecht!");
                            return EncounterResult.Continue;
                        }
                        else
                        {
                            Console.WriteLine("Je probeert je te verdedigen, maar je bent niet sterk genoeg...");
                            return EncounterResult.Death;
                        }
                    }
                    break;
            }

            gameState.EncounterNumber++;
            return EncounterResult.Continue;
        }
    }
}