using System;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Characters.Scripts.Weapon
{
    [Serializable]
    public class WeaponProperties
    {
        public WeaponType WeaponType { get; set; }
        public MagicType MagicType { get; set; }
        public int SpriteIndex { get; set; }
        public int AttackScore { get; set; }

        public WeaponProperties(WeaponType weaponType, MagicType magicType, int spriteIndex, int attackScore)
        {
            WeaponType = weaponType;
            MagicType = magicType;
            SpriteIndex = spriteIndex;
            AttackScore = attackScore;
        }
    }
}