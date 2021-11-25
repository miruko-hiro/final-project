using System;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    [Serializable]
    public class BodyProperties
    {
        public ArmorType ArmorType { get; set; }
        public int SpriteIndex { get; set; }
        public int ProtectionScore { get; set; }

        public BodyProperties(ArmorType armorType, int spriteIndex, int protectionScore)
        {
            ArmorType = armorType;
            SpriteIndex = spriteIndex;
            ProtectionScore = protectionScore;
        }
    }
}