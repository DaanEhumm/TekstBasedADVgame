using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedADV
{
    internal static class EndingHandler
    {
        public static void ShowEnding(Player player)
        {
            var dobbelsteen = new DobbelSteen();
            int roll = dobbelsteen.Roll();

            switch (roll)
            {
                case 1:
                    Console.WriteLine("Einde: Je hebt de stad gered, maar er is veel verwoest.");
                    break;
                case 2:
                    Console.WriteLine("Einde: De stad is gevallen. Je hebt gefaald.");
                    break;
                case 3:
                    Console.WriteLine("Einde: Je hebt de vijand laten vluchten.");
                    break;
                case 4:
                    Console.WriteLine("Einde: Je hebt de vijand verslagen, maar tegen een hoge prijs vrienden zijn verloren gegaa .");
                    break;
                case 5:
                    Console.WriteLine("Einde: Je hebt de stad gered, maar net als marvel is alles kapot .");
                    break;
                case 6:
                    Console.WriteLine("Einde: Je bent de Held van het rijk! Je naam zal worden herinnerd.");
                    break;
            }
        }
    }
}

