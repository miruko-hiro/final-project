using System;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    [Serializable]
    public class HeadProperties
    {
        public ArmorType ArmorType { get; set; }
        public int SpriteIndex { get; set; }
        public int ProtectionScore { get; set; }

        public HeadProperties(ArmorType armorType, int spriteIndex, int protectionScore)
        {
            ArmorType = armorType;
            SpriteIndex = spriteIndex;
            ProtectionScore = protectionScore;
        }
    }
}