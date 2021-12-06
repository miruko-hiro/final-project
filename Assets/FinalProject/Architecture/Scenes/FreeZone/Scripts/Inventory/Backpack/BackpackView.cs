using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack
{
    public class BackpackView : MonoBehaviour
    {
        private ItemButton[] _items;

        private void Awake()
        {
            _items = GetComponentsInChildren<ItemButton>();
            foreach (var item in _items)
            {
                item.Initialize(null, null);
            }
        }
    }
}