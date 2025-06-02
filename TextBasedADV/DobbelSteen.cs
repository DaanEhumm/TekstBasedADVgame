using System;
using System.Threading;

namespace TextBasedADV
{
    public class DobbelSteen
    {
        private Random _random = new();

        public int RollWithAnimation()
        {
            Console.Write("Dobbelsteen rolt: ");
            int roll = 0;
            for (int i = 0; i < 15; i++)
            {
                roll = _random.Next(1, 17);
                Console.Write($"\rDobbelsteen rolt: {roll}   ");
                Thread.Sleep(180);
            }
            Console.WriteLine();
            return roll;
        }
    }
}