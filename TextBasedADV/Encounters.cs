using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedADV
{
    internal enum EncounterResult
    {
        Continue,
        Death
    }

    internal class Encounter
    {
        private readonly int _number;

        public Encounter(int Number)
        {
            Number = _number;
        }

        public EncounterResult Resolve(int roll, Player player)
        {
            Console.WriteLine($"Encounter {_number}:");
            // Basislogica, later uitbreidbaar
            if (_number == 3 && roll == 1)
            {
                Console.WriteLine("Oh nee! Je liep in een val en overleed...");
                return EncounterResult.Death;
            }

            Console.WriteLine($"Je overleefde encounter {_number}.");
            return EncounterResult.Continue;
        }
    }
}

