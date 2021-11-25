using System;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Characters.Scripts.Weapon
{
    [Serializable]
    public class ShieldProperties
    {
        public ShieldType ShieldType { get; set; }
        public int SpriteIndex { get; set; }
        public int ProtectionScore { get; set; }

        public ShieldProperties(ShieldType shieldType, int spriteIndex, int protectionScore)
        {
            ShieldType = shieldType;
            SpriteIndex = spriteIndex;
            ProtectionScore = protectionScore;
        }
    }
}