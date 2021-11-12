using Core.Interfaces;
using Template.Creatures;

namespace Core.Player
{
    public class CharacterDataInstaller
    {
        public Humanoid LoadData(Humanoid humanoid, ICharacterData data)
        {
            humanoid.Race = data.HumanoidRaceSprite;
            humanoid.Hair = data.HairSprite;
            humanoid.Beard = data.BeardSprite;
            
            humanoid.HeadArmor = data.HeadArmorSprite;
            humanoid.BodyArmor = data.BodyArmorSprite;
            humanoid.PantsArmor = data.PantsArmorSprite;
            humanoid.BootsArmor = data.BootsArmorSprite;

            humanoid.LeftHand = data.ShieldSprite;

            humanoid.RightHand = data.WeaponSprite != null ? data.WeaponSprite : data.MagicWeaponSprite;

            return humanoid;
        }
    }
}