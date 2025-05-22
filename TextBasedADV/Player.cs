using System;
using System.Collections.Generic;

namespace TextBasedADV
{
    internal class Player
    {
        private  PlayerClass _class;
        private  Health _health;
        private  List<string> _inventory = new();

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