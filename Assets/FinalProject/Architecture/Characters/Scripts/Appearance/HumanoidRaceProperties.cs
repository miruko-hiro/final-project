using System;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Characters.Scripts.Appearance
{
    [Serializable]
    public class HumanoidRaceProperties
    {
        public HumanoidRace Race { get; set; }
        public HumanoidGender Gender { get; set; }
        public int SpriteIndex { get; set; }

        public HumanoidRaceProperties(HumanoidRace race, HumanoidGender gender, int spriteIndex)
        {
            Race = race;
            Gender = gender;
            SpriteIndex = spriteIndex;
        }
    }
}