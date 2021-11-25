using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Hair
{
    public class BeardCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] whiteMustaches = new Sprite[3];
        [SerializeField] private Sprite[] wheatMustaches = new Sprite[3];
        [SerializeField] private Sprite[] redMustaches = new Sprite[3];
        [SerializeField] private Sprite[] gingerMustaches = new Sprite[3];
        [SerializeField] private Sprite[] blackMustaches = new Sprite[3];
        [Space(10)]
        [SerializeField] private Sprite[] whiteBeards = new Sprite[4];
        [SerializeField] private Sprite[] wheatBeards = new Sprite[4];
        [SerializeField] private Sprite[] redBeards = new Sprite[4];
        [SerializeField] private Sprite[] gingerBeards = new Sprite[4];
        [SerializeField] private Sprite[] blackBeards = new Sprite[4];
        
        public Sprite GetSprite(int index, BeardLength type, HairColor color)
        {
            return type switch
            {
                BeardLength.Mustache => color switch
                {
                    HairColor.White => whiteMustaches[index],
                    HairColor.Wheat => wheatMustaches[index],
                    HairColor.Red => redMustaches[index],
                    HairColor.Ginger => gingerMustaches[index],
                    HairColor.Black => blackMustaches[index],
                    _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
                },
                BeardLength.Beard => color switch
                {
                    HairColor.White => whiteBeards[index],
                    HairColor.Wheat => wheatBeards[index],
                    HairColor.Red => redBeards[index],
                    HairColor.Ginger => gingerBeards[index],
                    HairColor.Black => blackBeards[index],
                    _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
                },
                BeardLength.None => null,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}