using System;

namespace FinalProject.Architecture.Barrels.Scripts
{
    public class BarrelData
    {
        public event Action<int> ChangeHealth;

        private int _health;

        public int Health
        {
            get => _health;
            set
            {
                ChangeHealth?.Invoke(value);
                _health = value;
            } 
        }

        public BarrelData(int health)
        {
            Health = health;
        }
    }
}