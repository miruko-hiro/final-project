using System;

namespace FinalProject.Architecture.Characters.Scripts
{
    public class Parameter<T>
    {
        public event Action<T> Change;
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                Change?.Invoke(_value);
            }
        }
    }
}