using Template.Creatures.Appearance.Armor;
using Template.Creatures.Appearance.Hair;
using Template.Creatures.Appearance.Weapon;
using Template.Creatures.Types;
using UnityEngine;
using UnityEngine.UIElements;

namespace Template.Creatures.Appearance
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

        public Sprite GetHumanoid(int index, HumanoidRace race, HumanoidGender gender)
        {
            return humanoidCollection.GetSprite(index, race, gender);
        }

        public Sprite GetHairHead(int index, HairLength type, HairColor color)
        {
            return hairHeadCollection.GetSprite(index, type, color);
        }

        public Sprite GetBeard(int index, BeardLength type, HairColor color)
        {
            return beardCollection.GetSprite(index, type, color);
        }

        public Sprite GetHeadArmor(int index, ArmorType type)
        {
            return headCollection.GetSprite(index, type);
        }

        public Sprite GetBodyArmor(int index, ArmorType type)
        {
            return bodyCollection.GetSprite(index, type);
        }

        public Sprite GetPantsArmor(int index)
        {
            return pantsCollection.GetSprite(index);
        }

        public Sprite GetBootsArmor(int index)
        {
            return bootsCollection.GetSprite(index);
        }

        public Sprite GetMagicalWeapon(int index, MagicType type)
        {
            return rightHandCollection.GetMagicSprite(index, type);
        }

        public Sprite GetWeapon(int index, WeaponType type)
        {
            return rightHandCollection.GetSprite(index, type);
        }

        public Sprite GetShield(int index, ShieldType type)
        {
            return leftHandCollection.GetSprite(index, type);
        }
    }
}