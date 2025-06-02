using System;

namespace TextBasedADV
{
    public abstract class Encounter
    {
        public abstract string Name { get; }
        protected abstract string description { get; }

        public void Describe()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---\n");
            Console.WriteLine(description);
        }

        public abstract EncounterResult Resolve(int roll, Player player, GameState gameState);
    }
}
