using System;
using System.Threading;

namespace TextBasedADV
{
    public class FinalBossEncounter : Encounter
    {
        public override string Name => "Final Boss: De Draak";

        protected override string description =>
            "Je staat oog in oog met de draak! Gebruik je vaardigheden en voorwerpen om hem te verslaan.";

        public override EncounterResult Resolve(int ignoredRoll, Player player, GameState gameState)
        {
            Console.Clear();
            Console.WriteLine("De lucht wordt zwart. Vleugels spreiden zich uit boven je — de draak is hier.");
            Thread.Sleep(3000);

            string itemName = player.Class switch
            {
                PlayerClass.Wizard => "Oude Magische Steen",
                PlayerClass.Soldier => "Versterkt Zwaard",
                PlayerClass.Knight => "Helm van Licht",
                _ => "Onbekend Artefact"
            };

            bool heeftArtefact = player.HasItem(itemName);
            bool heeftGeneeskruid = player.HasItem("Geneeskruid");

            // Mogelijkheid om geneeskruid te gebruiken
            if (heeftGeneeskruid && player.Health.Current < 100)
            {
                Console.WriteLine("\nJe voelt pijn in je lichaam van eerdere gevechten.");
                Console.WriteLine("Je hebt een Geneeskruid in je tas. Wil je het gebruiken om volledig te herstellen?");
                Console.WriteLine("1. Ja, gebruik het geneeskruid.");
                Console.WriteLine("2. Nee, bewaar het voor later (maar er is geen later).");

                int keuze = 0;
                while (keuze != 1 && keuze != 2)
                {
                    Console.Write("Jouw keuze: ");
                    int.TryParse(Console.ReadLine(), out keuze);
                }

                if (keuze == 1)
                {
                    Console.WriteLine("Je gebruikt het geneeskruid. Je voelt je krachten terugkeren!");
                    player.Health.Heal(100); 
                    player.RemoveItem("Geneeskruid");
                    Thread.Sleep(1500);
                }
                else
                {
                    Console.WriteLine("Je bewaart het geneeskruid... voor een moment dat nooit meer komt.");
                }
            }

            if (heeftArtefact)
            {
                Console.WriteLine($"\nJe voelt de kracht van je {itemName} pulseren in je handen.");
            }
            else
            {
                Console.WriteLine("\nJe hebt geen speciaal Artefact om je te helpen... Dit gevecht zal zwaar zijn.");
            }

            int damageDealt = 0;
            int damageToPlayer = 0;
            int maxDamageNeeded = 5;

            var dobbelsteen = new DobbelSteen();

            for (int ronde = 1; ronde <= 5; ronde++)
            {
                Console.WriteLine($"\nRonde {ronde}: Kies je actie:");
                Console.WriteLine("1. Aanval");
                Console.WriteLine("2. Verdediging");
                if (heeftArtefact)
                {
                    Console.WriteLine("3. Speciale aanval (met je " + itemName + ")");
                }

                int actie = 0;
                while (actie < 1 || actie > (heeftArtefact ? 3 : 2))
                {
                    Console.Write("Jouw keuze: ");
                    int.TryParse(Console.ReadLine(), out actie);
                }

                Console.WriteLine("Druk op SPATIE om te dobbelen...");
                while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

                int roll = dobbelsteen.RollWithAnimation();

                switch (actie)
                {
                    case 1:
                        if (roll >= 8)
                        {
                            Console.WriteLine("Je aanval raakt de draak!");
                            damageDealt++;
                        }
                        else
                        {
                            Console.WriteLine("Je aanval mist...");
                            damageToPlayer++;
                        }
                        break;

                    case 2:
                        if (roll >= 6)
                        {
                            Console.WriteLine("Je blokkeert de aanval van de draak!");
                        }
                        else
                        {
                            Console.WriteLine("Je verdediging faalt...");
                            damageToPlayer++;
                        }
                        break;

                    case 3:
                        if (roll >= 10)
                        {
                            Console.WriteLine($"Je roept de kracht van je {itemName} op en treft de draak dodelijk!");
                            damageDealt += 2;
                        }
                        else
                        {
                            Console.WriteLine($"Je probeert je {itemName} te gebruiken, maar de magie faalt...");
                            damageToPlayer++;
                        }
                        break;
                }

                // Bonus:
                if (heeftArtefact)
                {
                    Console.WriteLine($"De kracht van je {itemName} versterkt je aanval!");
                    damageDealt++;
                }

                Console.WriteLine($"Totale schade aan de draak: {damageDealt}");
                Console.WriteLine($"De draak heeft jou {damageToPlayer} keer geraakt.");
                Thread.Sleep(1500);

                player.Health.TakeDamage(damageToPlayer * 10);
                if (player.Health.IsDead)
                {
                    Console.WriteLine("\nJe bezwijkt aan je verwondingen. De draak laat een overwinningsbrul horen...");
                    Console.WriteLine("Het land blijft in duisternis gehuld.");
                    Console.WriteLine("\nBedankt voor het spelen!");
                    return EncounterResult.Death;
                }

                if (damageDealt >= maxDamageNeeded)
                {
                    Console.WriteLine("\nJe brengt de beslissende slag toe! De draak stort neer met een donderend gebrul.");
                    Console.WriteLine("\nBedankt voor het spelen!");
                    return EncounterResult.Continue;
                }
            }

            Console.WriteLine("\nJe hebt niet genoeg schade toegebracht. De draak overmeestert je...");
            Console.WriteLine("Het land blijft in duisternis gehuld.");
            Console.WriteLine("\nBedankt voor het spelen!");
            return EncounterResult.Death;
        }
    }
}