using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedADV
{
    internal class DobbelSteen
    {
        private readonly Random random = new();

        public int Roll()
        {
            return random.Next(1, 7); // 1 t/m 6
        }
    }
}

