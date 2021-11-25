using System;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    [Serializable]
    public class BootsProperties
    {
        public int SpriteIndex { get; set; }
        public int ProtectionScore { get; set; }

        public BootsProperties(int spriteIndex, int protectionScore)
        {
            SpriteIndex = spriteIndex;
            ProtectionScore = protectionScore;
        }
        
    }
}