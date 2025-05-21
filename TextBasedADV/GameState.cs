using System;

namespace TextBasedADV
{
    internal class GameState
    {
        internal bool HasTreasureMap { get; set; }
        internal bool HasFoundTreasure { get; set; }
        internal bool DragonAwakened { get; set; }
        internal int EncounterNumber { get; set; } = 1;
    }
}
