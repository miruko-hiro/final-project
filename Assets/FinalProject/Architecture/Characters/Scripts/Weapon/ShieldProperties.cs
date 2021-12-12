using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Items.Scripts;

namespace FinalProject.Architecture.Characters.Scripts.Weapon
{
    [Serializable]
    public class ShieldProperties: IItemProperties
    {
        public ItemType ItemType { get; set; }
        public ShieldType ShieldType { get; set; }
        public int SpriteIndex { get; set; }
        public int ProtectionScore { get; set; }
        public int Price { get; }
        public string Name { get; }

        public ShieldProperties(ItemType itemType, ShieldType shieldType, int spriteIndex, int protectionScore, int price, string name)
        {
            ItemType = itemType;
            ShieldType = shieldType;
            SpriteIndex = spriteIndex;
            ProtectionScore = protectionScore;
            Price = price;
            Name = name;
        }
        
        public string GetString()
        {
            return "Item Type: Shield \nType: " + ShieldType + "\n"
                   + "Protection Score: " + ProtectionScore + "\n"
                   + "Price:" + Price;
        }
    }
}