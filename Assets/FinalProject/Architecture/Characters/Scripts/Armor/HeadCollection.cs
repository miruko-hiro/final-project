using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    public class HeadCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] lightArmors = new Sprite[16];
        [SerializeField] private Sprite[] mediumArmors = new Sprite[12];
        [SerializeField] private Sprite[] heavyArmors = new Sprite[8];

        public Sprite GetSprite(int index, ArmorType type)
        {
            return type switch
            {
                ArmorType.Light => lightArmors[index],
                ArmorType.Medium => mediumArmors[index],
                ArmorType.Heavy => heavyArmors[index],
                ArmorType.None => null,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public int GetRandomIndex(ArmorType type)
        {
            return type switch
            {
                ArmorType.Light => Random.Range(0, lightArmors.Length - 1),
                ArmorType.Medium => Random.Range(0, mediumArmors.Length - 1),
                ArmorType.Heavy => Random.Range(0, heavyArmors.Length - 1),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}