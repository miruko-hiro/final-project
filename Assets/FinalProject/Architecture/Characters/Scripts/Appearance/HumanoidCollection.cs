using System;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Appearance
{
    public class HumanoidCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] maleHumans = new Sprite[3]; 
        [SerializeField] private Sprite[] femaleHumans = new Sprite[3];
        [Space(10)] 
        [SerializeField] private Sprite[] maleOrcs = new Sprite[1]; 
        [SerializeField] private Sprite[] femaleOrcs = new Sprite[1];

        public Sprite GetSprite(int index, HumanoidRace race, HumanoidGender gender)
        {
            return race switch
            {
                HumanoidRace.Human => gender switch
                {
                    HumanoidGender.Male => maleHumans[index],
                    HumanoidGender.Female => femaleHumans[index],
                    _ => throw new ArgumentOutOfRangeException(nameof(gender), gender, null)
                },
                HumanoidRace.Orc => gender switch
                {
                    HumanoidGender.Male => maleOrcs[index],
                    HumanoidGender.Female => femaleOrcs[index],
                    _ => throw new ArgumentOutOfRangeException(nameof(gender), gender, null)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(race), race, null)
            };
        }
    }
}