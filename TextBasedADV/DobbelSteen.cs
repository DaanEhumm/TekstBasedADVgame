using System;
using System.Threading;

namespace TextBasedADV
{
    internal class DobbelSteen
    {
        private readonly Random _random = new();

        public int RollWithAnimation()
        {
            Console.Write("Dobbelsteen rolt: ");
            int roll = 0;
            for (int i = 0; i < 15; i++)
            {
                roll = _random.Next(1, 17); // 1 t/m 16
                Console.Write($"\rDobbelsteen rolt: {roll}   ");
                Thread.Sleep(200);
            }
            return roll;
        }
    }
}