using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item
{
    public class ItemView : MonoBehaviour
    {
        public event Action OnAddInfoToInfoWindowEvent;
        
        [SerializeField] private Image _image;
        public IItemPresenter Presenter { get; private set; }
        
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
        
        public ItemType ItemType { get; private set; }
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(AddInfoToInfoWindow);
        }

        public void Initialize(ItemType type, IItemPresenter presenter)
        {
            ItemType = type;
            Presenter = presenter;
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
            Presenter = null;
            GetComponent<Button>().onClick.AddListener(AddInfoToInfoWindow);
        }
    }
}