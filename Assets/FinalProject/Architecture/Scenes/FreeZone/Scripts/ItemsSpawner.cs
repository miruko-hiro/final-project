using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private BuyWindow _buyWindow;
        private GameManager _gameManager;
        private AppearanceIssuanceSystem _dispenser;

        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _gameManager = gameManager;
            _dispenser = dispenser;
        }

        private void Awake()
        {
            var items = _buyWindow.GetItems();
            var level = _gameManager.GetInteractor<PlayerLevelInteractor>().Level;
            
            var valuesItemType = Enum.GetValues(typeof(ItemType));
            var valuesArmorType = Enum.GetValues(typeof(ArmorType));

            foreach (var item in items)
            {
                var itemTypeRandom = (ItemType)valuesItemType.GetValue(Random.Range(3, valuesItemType.Length - 1));
                ArmorType armorTypeRandom;

                if (itemTypeRandom == ItemType.Pants || itemTypeRandom == ItemType.Boots)
                    armorTypeRandom = ArmorType.None;
                else 
                    armorTypeRandom = (ArmorType)valuesArmorType.GetValue(Random.Range(1, valuesArmorType.Length - 1));

                var spriteIndexRandom = _dispenser.GetRandomIndex(itemTypeRandom, armorTypeRandom);
                var protectionScoreRandom = Random.Range(1, 3) * level;
                var priceRandom = Random.Range(5, 10) * level;

                var properties = new ArmorProperties(itemTypeRandom, armorTypeRandom, spriteIndexRandom, protectionScoreRandom, priceRandom, "item");
                var sprite = _dispenser.GetArmorSprite(properties);
                
                item.Initialize(sprite, properties);
            }
        }
    }
}
