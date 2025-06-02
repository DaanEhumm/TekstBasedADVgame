using System;

namespace TextBasedADV
{
    public class FinalBossEncounter : Encounter
    {
        public override string Name => "Final Boss: De Draak";
        protected override string description =>
            "Je staat oog in oog met de draak! Om hem te verslaan, moet je slimme keuzes maken en je dobbelstenen goed rollen.";

        public override EncounterResult Resolve(int ignoredRoll, Player player, GameState gameState)
        {
            Console.WriteLine("Je nadert de draak met vastberadenheid. De lucht trilt van zijn gebrul en de grond beeft onder zijn gewicht.");
            Thread.Sleep(3000);

            string requiredItem = player.Class switch
            {
                PlayerClass.Wizard => "Oude Magische Steen",
                PlayerClass.Soldier => "Versterkt Zwaard",
                PlayerClass.Knight => "Helm van Licht",
                _ => "Zeldzaam Artefact"
            };

            if (!player.HasItem(requiredItem))
            {
                Console.WriteLine("\nJe hebt niet het speciale artefact van jouw klasse en mist daardoor cruciale kracht...");
                return EncounterResult.Death;
            }

            Console.WriteLine("\nJe hebt het speciale artefact: " + requiredItem);
            Console.WriteLine("Bereid je voor op de strijd!");

            int damageDealt = 0;
            int damageToPlayer = 0;
            int maxDamageNeeded = 5;
            var dobbelsteen = new DobbelSteen();

            for (int ronde = 1; ronde <= 5; ronde++)
            {
                Console.WriteLine($"\nRonde {ronde}: Kies je actie:");
                Console.WriteLine("1. Aanval");
                Console.WriteLine("2. Verdediging");
                Console.WriteLine("3. Magische aanval");

                int keuze = 0;
                while (keuze < 1 || keuze > 3)
                {
                    Console.Write("Jouw keuze (1-3): ");
                    int.TryParse(Console.ReadLine(), out keuze);
                }

                Console.WriteLine("Druk op SPATIE om te dobbelen...");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

                int roll = dobbelsteen.RollWithAnimation();

                bool actieSuccesvol = false;

                switch (keuze)
                {
                    case 1: // Aanval
                        if (roll >= 8)
                        {
                            Console.WriteLine("Je aanval raakt de draak!");
                            damageDealt++;
                            actieSuccesvol = true;
                        }
                        else
                        {
                            Console.WriteLine("Je aanval mist...");
                            damageToPlayer++;
                        }
                        break;

                    case 2: // Verdediging
                        if (roll >= 6)
                        {
                            Console.WriteLine("Je blokkeert de aanval van de draak!");
                            actieSuccesvol = true;
                        }
                        else
                        {
                            Console.WriteLine("Je verdediging faalt...");
                            damageToPlayer++;
                        }
                        break;

                    case 3: // Speciale aanval
                        if (roll >= 10)
                        {
                            Console.WriteLine("Je speciale aanval treft de draak dodelijk!");
                            damageDealt += 2; 
                            actieSuccesvol = true;
                        }
                        else
                        {
                            Console.WriteLine("Je speciale aanval faalt...");
                            damageToPlayer++;
                        }
                        break;
                }

                Console.WriteLine($"Je hebt {damageDealt} schade toegebracht aan de draak.");
                Console.WriteLine($"De draak heeft jou {damageToPlayer} keer geraakt.");
                Thread.Sleep(1500);

                player.Health.TakeDamage(damageToPlayer * 10);
                if (player.Health.IsDead)
                {
                    Console.WriteLine("Je bent bezweken in het gevecht...");
                    return EncounterResult.Death;
                }

                if (damageDealt >= maxDamageNeeded)
                {
                    Console.WriteLine("\nJe hebt genoeg schade toegebracht aan de draak!");
                    gameState.PlayerWon = true;
                    return EncounterResult.Continue;
                }
            }

            Console.WriteLine("\nJe hebt niet genoeg schade toegebracht en wordt verslagen...");
            return EncounterResult.Death;
        }
    }
}
