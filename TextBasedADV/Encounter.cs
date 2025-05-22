using System;

namespace TextBasedADV
{
    internal abstract class Encounter
    {
        public abstract string Name { get; }
        public abstract EncounterResult Resolve(int roll, Player player, GameState gameState);

        internal enum EncounterResult
        {
            Continue,
            Heal,
            Damage,
            Item,
            Death
        }
    }
}
