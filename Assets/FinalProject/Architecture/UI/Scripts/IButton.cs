using System;

namespace FinalProject.Architecture.UI.Scripts
{
    public interface IButton
    {
        public event Action Click;

        public void OnClick();
    }
}