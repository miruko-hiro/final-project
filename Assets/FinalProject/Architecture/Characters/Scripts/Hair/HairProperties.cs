using System;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Characters.Scripts.Hair
{
    [Serializable]
    public class HairProperties
    {
        public HairColor HairColor { get; set; }
        public HairLength HairLength { get; set; }
        public int SpriteIndex { get; set; }

        public HairProperties(HairColor hairColor, HairLength hairLength, int spriteIndex)
        {
            HairColor = hairColor;
            HairLength = hairLength;
            SpriteIndex = spriteIndex;
        }
    }
}