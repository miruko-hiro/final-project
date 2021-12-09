using FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory
{
    public abstract class PlayerItem: MonoBehaviour
    {
        public abstract void SetItem(ItemView item);
    }
}