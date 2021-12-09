﻿using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.PlayerItems
{
    public class PlayerBootsArmor: PlayerItem, IPlayerArmor
    {
        public event Action<ArmorProperties> OnAddItemEvent;

        [SerializeField] private InfoWindow _infoWindow;
        private PlayerArmorPresenter _presenter;
        private AppearanceIssuanceSystem _dispenser;

        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _presenter = new PlayerArmorPresenter(this, gameManager.GetInteractor<PlayerBootsInteractor>());
            _dispenser = dispenser;
        }

        private void Awake()
        {
            var item = GetComponentInChildren<ItemView>();
            item.Initialize(ItemType.Boots, new ItemArmorPresenter(item, _presenter.ArmorProperties, _dispenser, _infoWindow));
        }

        public override void SetItem(ItemView item)
        {
            OnAddItemEvent?.Invoke(item == null ? null : 
                (item.Presenter as ItemArmorPresenter)?.ArmorProperties);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}