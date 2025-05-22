using System;
using System.Collections.Generic;

namespace TextBasedADV
{
    internal class Player
    {
        private readonly PlayerClass _class;
        private readonly Health _health;
        private readonly List<string> _inventory = new();

        internal PlayerClass Class => _class;
        internal Health Health => _health;

        internal Player(PlayerClass playerClass)
        {
            _class = playerClass;
            _health = new Health(100);
        }

        internal void AddItem(string item)
        {
            _inventory.Add(item);
            Console.WriteLine($"Item verkregen: {item}");
        }

        internal bool HasItem(string item) => _inventory.Contains(item);
    }
}