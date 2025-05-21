using System;

namespace TextBasedADV
{
    internal class DobbelSteen
    {
        private readonly Random random = new();

        public int Roll()
        {
            return random.Next( 1 , 17 );
        }
    }
}

