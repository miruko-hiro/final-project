using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Items.Scripts;

namespace FinalProject.Architecture.Characters.Scripts.Weapon
{
    [Serializable]
    public class WeaponProperties: IItemProperties
    {
        public ItemType ItemType { get; set; }
        public WeaponType WeaponType { get; set; }
        public MagicType MagicType { get; set; }
        public int SpriteIndex { get; set; }
        public int AttackScore { get; set; }
        public int Price { get; }
        public string Name { get; }

        public WeaponProperties(ItemType itemType, WeaponType weaponType, MagicType magicType, int spriteIndex, int attackScore, int price, string name)
        {
            ItemType = itemType;
            WeaponType = weaponType;
            MagicType = magicType;
            SpriteIndex = spriteIndex;
            AttackScore = attackScore;
            Price = price;
            Name = name;
        }

        public string GetString()
        {
            return "Item Type: Weapon \nType: " + WeaponType + "\n"
                   + "Magic Type: " + MagicType + "\n"
                   + "Attack Score: " + AttackScore + "\n"
                   + "Price:" + Price;
        }
    }
}