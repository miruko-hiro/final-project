using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.ItemArmor
{
    public class PlayerArmor : MonoBehaviour
    {
        public event Action OnAddInfoToInfoWindowEvent;
        
        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private Image _image;
        [SerializeField] private ItemType _itemType;
        private PlayerArmorPresenter _presenter;
        
        public Sprite Sprite
        {
            get => _image.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(_image, 0f);
                    return;
                }
                _image.sprite = value;
                SetAlpha(_image, 1f);
            }
        }


        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            var interactor = GetInteractor(_itemType, gameManager);

            _presenter = new PlayerArmorPresenter(this, interactor, dispenser, _infoWindow);
        }
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(AddInfoToInfoWindow);
        }
        
        private void AddInfoToInfoWindow()
        {
            OnAddInfoToInfoWindowEvent?.Invoke();
        }

        private PlayerArmorInteractor GetInteractor(ItemType type, GameManager gameManager)
        {
            return type switch
            {
                ItemType.Head => gameManager.GetInteractor<PlayerHeadInteractor>(),
                ItemType.Body => gameManager.GetInteractor<PlayerBodyInteractor>(),
                ItemType.Pants => gameManager.GetInteractor<PlayerPantsInteractor>(),
                ItemType.Boots => gameManager.GetInteractor<PlayerBootsInteractor>(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        private void SetAlpha(Image image, float count)
        {
            var tempColor = image.color;
            tempColor.a = count;
            image.color = tempColor;
        }

        private void OnDestroy()
        {
            _presenter = null;
            GetComponent<Button>().onClick.AddListener(AddInfoToInfoWindow);
        }
    }
}