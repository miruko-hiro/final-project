using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    public class BodyCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] lightArmors = new Sprite[48];
        [SerializeField] private Sprite[] mediumArmors = new Sprite[48];
        [SerializeField] private Sprite[] heavyArmors = new Sprite[24];

        public Sprite GetSprite(int index, ArmorType type)
        {
            return type switch
            {
                ArmorType.Light => lightArmors[index],
                ArmorType.Medium => mediumArmors[index],
                ArmorType.Heavy => heavyArmors[index],
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}