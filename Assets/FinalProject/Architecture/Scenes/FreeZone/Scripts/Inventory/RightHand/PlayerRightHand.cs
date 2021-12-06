using System;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.RightHand
{
    public class PlayerRightHand : MonoBehaviour
    {
        public event Action OnAddInfoToInfoWindowEvent;
        
        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private Image _image;
        private PlayerRightHandPresenter _presenter;
        
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
            _presenter = new PlayerRightHandPresenter(this, gameManager, dispenser, _infoWindow);
        }

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(AddInfoToInfoWindow);
        }
        
        private void AddInfoToInfoWindow()
        {
            OnAddInfoToInfoWindowEvent?.Invoke();
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