using System;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI.Selectors
{
    public class BaseSelector : MonoBehaviour
    {
        public event Action<SelectionType> Changed;
        private SoundEffectsButtons _soundEffectsButtons;

        [Inject]
        private void Construct(SoundEffectsButtons soundEffectsButtons)
        {
            _soundEffectsButtons = soundEffectsButtons;
        }

        public void OnLeftButtonClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            Changed?.Invoke(SelectionType.Prev);
        }

        public void OnRightButtonClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            Changed?.Invoke(SelectionType.Next);
        }
    }
}