using System;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Interactors.Scripts;

namespace FinalProject.Architecture.Characters.Player.Interactors
{
    public abstract class PlayerArmorInteractor: Interactor
    {
        public abstract event Action<ArmorProperties> ChangeArmorEvent;
        
        public abstract ArmorProperties ArmorProperties { get; set; }
    }
}