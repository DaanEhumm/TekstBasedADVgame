using System;

namespace TextBasedADV
{
    internal class Health
    {
        private int _current;
        private readonly int _max;

        internal int Current => _current;
        internal bool IsDead => _current <= 0;

        internal Health(int max)
        {
            _max = max;
            _current = max;
        }

        internal void TakeDamage(int amount)
        {
            _current -= amount;
            if (_current < 0) _current = 0;
            Console.WriteLine($"Je nam {amount} schade. HP: {_current}/{_max}");
        }

        internal void Heal(int amount)
        {
            _current += amount;
            if (_current > _max) _current = _max;
            Console.WriteLine($"Je genas {amount} HP. HP: {_current}/{_max}");
        }
    }
}