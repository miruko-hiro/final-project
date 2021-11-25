using System;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    [Serializable]
    public class PantsProperties
    {
        public int SpriteIndex { get; set; }
        public int ProtectionScore { get; set; }

        public PantsProperties(int spriteIndex, int protectionScore)
        {
            SpriteIndex = spriteIndex;
            ProtectionScore = protectionScore;
        }
    }
}