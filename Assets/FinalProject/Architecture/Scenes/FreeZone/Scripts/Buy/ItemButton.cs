using FinalProject.Architecture.Characters.Scripts.Armor;
using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy
{
    public class ItemButton : MonoBehaviour
    {
        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private Image _image;
        private ArmorProperties _armorProperties;
        
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

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(AddInfoToInfoWindow);
        }

        public void Initialize(Sprite sprite, ArmorProperties armorProperties)
        {
            Sprite = sprite;
            _armorProperties = armorProperties;
        }

        private void SetAlpha(Image image, float count)
        {
            var tempColor = image.color;
            tempColor.a = count;
            image.color = tempColor;
        }

        private void AddInfoToInfoWindow()
        {
            _infoWindow.AddInfo(_armorProperties);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.AddListener(AddInfoToInfoWindow);
        }
    }
}
