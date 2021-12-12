using System;
using FinalProject.Architecture.Characters.Scripts.Armor;

namespace FinalProject.Architecture.Inventory.PlayerItems
{
    public interface IPlayerArmor
    {
        public event Action<ArmorProperties> OnAddItemEvent;
    }
}