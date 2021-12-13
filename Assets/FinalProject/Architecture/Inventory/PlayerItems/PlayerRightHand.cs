using System;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Inventory.Backpack.Item;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Inventory.PlayerItems
{
    public class PlayerRightHand : PlayerItem
    {
        public event Action<WeaponProperties> OnAddItemToRightHandEvent;

        [SerializeField] private InfoWindow _infoWindow;
        private PlayerRightHandPresenter _presenter;
        private AppearanceIssuanceSystem _dispenser;
        private GameManager _gameManager;


        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _gameManager = gameManager;
            _dispenser = dispenser;
        }

        private void Awake()
        {
            _presenter = new PlayerRightHandPresenter(this, _gameManager);
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