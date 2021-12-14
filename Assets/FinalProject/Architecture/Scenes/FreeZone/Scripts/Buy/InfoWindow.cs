using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Items.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy
{
    public class InfoWindow : MonoBehaviour
    {
        [SerializeField] private Text _name;
        [SerializeField] private Text _info;
        [SerializeField] private Image _image;
        private AppearanceIssuanceSystem _dispenser;
        public IItemProperties ItemProperties { get; private set; }
        public GameObject ItemObject { get; private set; }
        private SoundEffectsButtons _soundEffectsButtons;
        
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
        private void Construct(AppearanceIssuanceSystem dispenser, SoundEffectsButtons soundEffectsButtons)
        {
            _dispenser = dispenser;
            _soundEffectsButtons = soundEffectsButtons;
        }

        private void SetAlpha(Image image, float count)
        {
            var tempColor = image.color;
            tempColor.a = count;
            image.color = tempColor;
        }
        
        public void OnClickBack()
        {
            _soundEffectsButtons.SoundEffectBack();
            gameObject.SetActive(false);
        }

        public void AddInfo<T>(T properties, GameObject gameObj) where T: IItemProperties
        {
            if(properties == null) return;
            ItemObject = gameObj;
            ItemProperties = properties;

            _name.text = properties.Name;
            _info.text = properties.GetString();

            Sprite = properties.ItemType switch
            {
                ItemType.Weapon => _dispenser.GetWeapon(properties as WeaponProperties),
                ItemType.Shield => _dispenser.GetShield(properties as ShieldProperties),
                _ => _dispenser.GetArmorSprite(properties as ArmorProperties)
            };
        }
    }
}
