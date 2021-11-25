using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Weapon
{
    public class RightHandCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] fireStaffs = new Sprite[5];
        [SerializeField] private Sprite[] iceStaffs = new Sprite[5];
        [SerializeField] private Sprite[] voidStaffs = new Sprite[5];
        [SerializeField] private Sprite[] poisonStaffs = new Sprite[5];
        [Space(10)]
        [SerializeField] private Sprite[] bows = new Sprite[10];
        [SerializeField] private Sprite[] swords = new Sprite[20];
        [SerializeField] private Sprite[] axes = new Sprite[18];
        [SerializeField] private Sprite[] clubs = new Sprite[12];
        [SerializeField] private Sprite[] lances = new Sprite[12];
        [SerializeField] private Sprite[] poleaxes = new Sprite[18];

        private Sprite GetMagicSprite(int index, MagicType type)
        {
            return type switch
            {
                MagicType.Fire => fireStaffs[index],
                MagicType.Ice => iceStaffs[index],
                MagicType.Void => voidStaffs[index],
                MagicType.Poison => poisonStaffs[index],
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        
        public Sprite GetSprite(int index, WeaponType type, MagicType magicType)
        {
            return type switch
            {
                WeaponType.Bow => bows[index],
                WeaponType.Sword => swords[index],
                WeaponType.Axe => axes[index],
                WeaponType.Club => clubs[index],
                WeaponType.Lance => lances[index],
                WeaponType.Poleaxe => poleaxes[index],
                WeaponType.Staff => GetMagicSprite(index, magicType),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}