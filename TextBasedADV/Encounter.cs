using System;

namespace TextBasedADV
{
    public abstract class Encounter
    {
        public abstract string Name { get; }
        protected abstract string description { get; } // Dit moet even aangepast worden bij alle encounnter scripten kijk Merchant script

        public void Describe()
        {
            Console.WriteLine(description);    
        }
        public abstract EncounterResult Resolve(int roll, Player player, GameState gameState);
    }
}
