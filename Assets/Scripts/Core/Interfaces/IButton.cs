using System;

namespace Core.Interfaces
{
    public interface IButton
    {
        public event Action Click;

        public void OnClick();
    }
}