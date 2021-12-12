using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        private GameStateHelper _gameState;

        [Inject]
        private void Construct(GameStateHelper gameStateHelper)
        {
            _gameState = gameStateHelper;
        }

        public void OnClick()
        {
            _gameState.Pause();
            _inventoryPanel.SetActive(true);
        }

        public void OnExitClick()
        {
            _gameState.Play();
            _inventoryPanel.SetActive(false);
        }
    }
}