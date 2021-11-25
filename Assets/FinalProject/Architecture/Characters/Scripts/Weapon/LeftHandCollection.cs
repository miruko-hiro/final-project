using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Weapon
{
    public class LeftHandCollection : MonoBehaviour
    {
        [SerializeField] private Sprite[] bucklerShields = new Sprite[12];
        [SerializeField] private Sprite[] roundShields = new Sprite[12];
        [SerializeField] private Sprite[] knightsShields = new Sprite[12];
        [SerializeField] private Sprite[] squareShields = new Sprite[12];
        [SerializeField] private Sprite[] towerShields = new Sprite[12];

        public Sprite GetSprite(int index, ShieldType type)
        {
            return type switch
            {
                ShieldType.Buckler => bucklerShields[index],
                ShieldType.Round => roundShields[index],
                ShieldType.Knights => knightsShields[index],
                ShieldType.Square => squareShields[index],
                ShieldType.Tower => towerShields[index],
                ShieldType.None => null,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}