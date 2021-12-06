using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Items.Scripts;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    [Serializable]
    public class ArmorProperties: IItemProperties
    {
        public ItemType ItemType { get; set; }
        public ArmorType ArmorType { get; set; }
        public int SpriteIndex { get; set; }
        public int ProtectionScore { get; set; }
        public int Price { get; }
        public string Name { get; }

        public ArmorProperties(ItemType itemType, ArmorType armorType, int spriteIndex, int protectionScore, int price, string name)
        {
            ItemType = itemType;
            ArmorType = armorType;
            SpriteIndex = spriteIndex;
            ProtectionScore = protectionScore;
            Price = price;
            Name = name;
        }
        
        public string GetString()
        {
            return "Item Type: " + ItemType + "\n"
                   + "Armor Type: " + ArmorType + "\n"
                   + "Protection Score: " + ProtectionScore;
        }
    }
}