using Template.Creatures.Types;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterData
    {
        public HumanoidRace HumanoidRace { get; set; }
        public Sprite HumanoidRaceSprite { get; set; }
        public HumanoidGender HumanoidGender { get; set; }
        
        public Sprite HairSprite { get; set; }
        public Sprite BeardSprite { get; set; }
        
        public Sprite HeadArmorSprite { get; set; }
        public Sprite BodyArmorSprite { get; set; }
        public Sprite PantsArmorSprite { get; set; }
        public Sprite BootsArmorSprite { get; set; }
        
        public Sprite ShieldSprite { get; set; }
        public Sprite WeaponSprite { get; set; }
        public Sprite MagicWeaponSprite { get; set; }
    }
}