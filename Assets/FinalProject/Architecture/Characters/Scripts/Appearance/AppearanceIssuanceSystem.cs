using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Appearance
{
    public class AppearanceIssuanceSystem : MonoBehaviour
    {
        [Space(10)] 
        [SerializeField] private HumanoidCollection humanoidCollection;
        [SerializeField] private HairHeadCollection hairHeadCollection;
        [SerializeField] private BeardCollection beardCollection;
        [Space(10)]
        [SerializeField] private HeadCollection headCollection;
        [SerializeField] private BodyCollection bodyCollection;
        [SerializeField] private PantsCollection pantsCollection;
        [SerializeField] private BootsCollection bootsCollection;
        [Space(10)]
        [SerializeField] private RightHandCollection rightHandCollection;
        [SerializeField] private LeftHandCollection leftHandCollection;

        public Sprite GetHumanoid(HumanoidRaceProperties raceProperties)
        {
            return humanoidCollection.GetSprite(raceProperties.SpriteIndex, raceProperties.Race, raceProperties.Gender);
        }

        public Sprite GetHairHead(HairProperties hairProperties)
        {
            return hairHeadCollection.GetSprite(hairProperties.SpriteIndex, hairProperties.HairLength, hairProperties.HairColor);
        }

        public Sprite GetBeard(BeardProperties beardProperties)
        {
            return beardCollection.GetSprite(beardProperties.SpriteIndex, beardProperties.BeardLength, beardProperties.BeardColor);
        }

        public Sprite GetHeadArmor(HeadProperties headProperties)
        {
            return headCollection.GetSprite(headProperties.SpriteIndex, headProperties.ArmorType);
        }

        public Sprite GetBodyArmor(BodyProperties bodyProperties)
        {
            return bodyCollection.GetSprite(bodyProperties.SpriteIndex, bodyProperties.ArmorType);
        }

        public Sprite GetPantsArmor(PantsProperties pantsProperties)
        {
            return pantsCollection.GetSprite(pantsProperties.SpriteIndex);
        }

        public Sprite GetBootsArmor(BootsProperties bootsProperties)
        {
            return bootsCollection.GetSprite(bootsProperties.SpriteIndex);
        }

        public Sprite GetWeapon(WeaponProperties weaponProperties)
        {
            return rightHandCollection.GetSprite(weaponProperties.SpriteIndex, weaponProperties.WeaponType, weaponProperties.MagicType);
        }

        public Sprite GetShield(ShieldProperties shieldProperties)
        {
            return leftHandCollection.GetSprite(shieldProperties.SpriteIndex, shieldProperties.ShieldType);
        }
    }
}