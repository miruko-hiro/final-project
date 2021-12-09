using System;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.PlayerItems
{
    public class PlayerRightHand : PlayerItem
    {
        public event Action<WeaponProperties> OnAddItemToRightHandEvent;

        [SerializeField] private InfoWindow _infoWindow;
        private PlayerRightHandPresenter _presenter;
        private AppearanceIssuanceSystem _dispenser;


        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _presenter = new PlayerRightHandPresenter(this, gameManager);
            _dispenser = dispenser;
        }

        private void Awake()
        {
            var item = GetComponentInChildren<ItemView>();
            item.Initialize(ItemType.Weapon, new ItemWeaponPresenter(item, _presenter.WeaponProperties, _dispenser, _infoWindow));
        }

        public override void SetItem(ItemView item)
        {
            OnAddItemToRightHandEvent?.Invoke(item == null ? null : 
                (item.Presenter as ItemWeaponPresenter)?.WeaponProperties);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}