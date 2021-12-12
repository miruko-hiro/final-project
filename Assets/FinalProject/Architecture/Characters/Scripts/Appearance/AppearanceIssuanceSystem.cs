using System;
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

        public Sprite GetHeadArmor(ArmorProperties headProperties)
        {
            return headCollection.GetSprite(headProperties.SpriteIndex, headProperties.ArmorType);
        }

        public Sprite GetBodyArmor(ArmorProperties bodyProperties)
        {
            return bodyCollection.GetSprite(bodyProperties.SpriteIndex, bodyProperties.ArmorType);
        }

        public Sprite GetPantsArmor(ArmorProperties pantsProperties)
        {
            return pantsCollection.GetSprite(pantsProperties.SpriteIndex);
        }

        public Sprite GetBootsArmor(ArmorProperties bootsProperties)
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

        public int GetRandomIndex(ItemType itemType, ArmorType armorType)
        {
            return itemType switch
            {
                ItemType.Head => headCollection.GetRandomIndex(armorType),
                ItemType.Body => bodyCollection.GetRandomIndex(armorType),
                ItemType.Pants => pantsCollection.GetRandomIndex(),
                ItemType.Boots => bootsCollection.GetRandomIndex(),
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null)
            };
        }

        public int GetRandomIndex(WeaponType weaponType, MagicType magicType)
        {
            return rightHandCollection.GetRandomIndex(weaponType, magicType);
        }

        public int GetRandomIndex(ShieldType shieldType)
        {
            return leftHandCollection.GetRandomIndex(shieldType);
        }

        public Sprite GetArmorSprite(ArmorProperties armorProperties)
        {
            return armorProperties.ItemType switch
            {
                ItemType.Head => GetHeadArmor(armorProperties),
                ItemType.Body => GetBodyArmor(armorProperties),
                ItemType.Pants => GetPantsArmor(armorProperties),
                ItemType.Boots => GetBootsArmor(armorProperties),
                _ => throw new ArgumentOutOfRangeException(nameof(armorProperties.ItemType), armorProperties.ItemType, null)
            };
        }
    }
}