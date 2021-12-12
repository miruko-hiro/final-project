using FinalProject.Architecture.Inventory.Backpack.Item;
using UnityEngine;

namespace FinalProject.Architecture.Inventory
{
    public abstract class PlayerItem: MonoBehaviour
    {
        public abstract void SetItem(ItemView item);
    }
}