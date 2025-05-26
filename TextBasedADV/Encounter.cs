using System;

namespace TextBasedADV
{
    public abstract class Encounter
    {
        public abstract string Name { get; }
        public abstract EncounterResult Resolve(int roll, Player player, GameState gameState);
    }
}
