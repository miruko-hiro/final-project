using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;

        public void OnClick()
        {
            _inventoryPanel.SetActive(true);
        }

        public void OnExitClick()
        {
            _inventoryPanel.SetActive(false);
        }
    }
}