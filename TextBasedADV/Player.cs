using System;
using System.Collections.Generic;

namespace TextBasedADV
{
    public class Player
    {
        private PlayerClass _class;
        private Health _health;
        private List<string> _inventory = new();

        public PlayerClass Class => _class;
        public Health Health => _health;

        public Player(PlayerClass playerClass)
        {
            _class = playerClass;
            _health = new Health(100);
        }

        public void AddItem(string item)
        {
            _inventory.Add(item);
            Console.WriteLine($"Item verkregen: {item}");
        }
        public void RemoveItem(string item)
        {
            if (_inventory.Contains(item))
            {
                _inventory.Remove(item);
                Console.WriteLine($"Item verwijderd: {item}");
            }
            else
            {
                Console.WriteLine($"Item niet gevonden: {item}");
            }
        }

        public bool HasItem(string item) => _inventory.Contains(item);
    }
}