using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Hair
{
    public class HairHeadCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] whiteLongHair = new Sprite[4];
        [SerializeField] private Sprite[] wheatLongHair = new Sprite[4];
        [SerializeField] private Sprite[] redLongHair = new Sprite[4];
        [SerializeField] private Sprite[] gingerLongHair = new Sprite[4];
        [SerializeField] private Sprite[] blackLongHair = new Sprite[4];
        [Space(10)]
        [SerializeField] private Sprite[] whiteShortHair = new Sprite[5];
        [SerializeField] private Sprite[] wheatShortHair = new Sprite[5];
        [SerializeField] private Sprite[] redShortHair = new Sprite[5];
        [SerializeField] private Sprite[] gingerShortHair = new Sprite[5];
        [SerializeField] private Sprite[] blackShortHair = new Sprite[5];

        public Sprite GetSprite(int index, HairLength type, HairColor color)
        {
            return type switch
            {
                HairLength.Long => color switch
                {
                    HairColor.White => whiteLongHair[index],
                    HairColor.Wheat => wheatLongHair[index],
                    HairColor.Red => redLongHair[index],
                    HairColor.Ginger => gingerLongHair[index],
                    HairColor.Black => blackLongHair[index],
                    _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
                },
                HairLength.Short => color switch
                {
                    HairColor.White => whiteShortHair[index],
                    HairColor.Wheat => wheatShortHair[index],
                    HairColor.Red => redShortHair[index],
                    HairColor.Ginger => gingerShortHair[index],
                    HairColor.Black => blackShortHair[index],
                    _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
                },
                HairLength.None => null,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}