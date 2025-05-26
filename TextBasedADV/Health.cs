using System;

namespace TextBasedADV
{
    public class Health
    {
        private int _current;
        private int _max;

        public int Current => _current;
        public bool IsDead => _current <= 0;

        public Health(int max)
        {
            _max = max;
            _current = max;
        }

        public void TakeDamage(int amount)
        {
            _current -= amount;
            if (_current < 0) _current = 0;
            Console.WriteLine($"Je nam {amount} schade. HP: {_current}/{_max}");
        }

        public void Heal(int amount)
        {
            _current += amount;
            if (_current > _max) _current = _max;
            Console.WriteLine($"Je genas {amount} HP. HP: {_current}/{_max}");
        }
    }
}