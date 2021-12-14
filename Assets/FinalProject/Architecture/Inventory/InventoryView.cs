using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        private GameStateHelper _gameState;
        private SoundEffectsButtons _soundEffectsButtons;

        [Inject]
        private void Construct(GameStateHelper gameStateHelper, SoundEffectsButtons soundEffectsButtons)
        {
            _gameState = gameStateHelper;
            _soundEffectsButtons = soundEffectsButtons;
        }

        public void OnClick()
        {
            _soundEffectsButtons.SoundEffectClick();
            _gameState.Pause();
            _inventoryPanel.SetActive(true);
        }

        public void OnExitClick()
        {
            _soundEffectsButtons.SoundEffectBack();
            _gameState.Play();
            _inventoryPanel.SetActive(false);
        }
    }
}