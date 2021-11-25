using System;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Characters.Scripts.Hair
{
    [Serializable]
    public class BeardProperties
    {
        public HairColor BeardColor { get; set; }
        public BeardLength BeardLength { get; set; }
        public int SpriteIndex { get; set; }

        public BeardProperties(HairColor beardColor, BeardLength beardLength, int spriteIndex)
        {
            BeardColor = beardColor;
            BeardLength = beardLength;
            SpriteIndex = spriteIndex;
        }
    }
}