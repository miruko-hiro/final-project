using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Types;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy
{
    public class EnemyData
    {
        public HumanoidRace HumanoidRace { get; set; }
        public HumanoidGender HumanoidGender { get; set; }
        public Parameter<Sprite> HumanoidRaceSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> HairSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> BeardSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> HeadArmorSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> BodyArmorSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> PantsArmorSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> BootsArmorSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> LeftHandSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<Sprite> RightHandSprite { get; set; } = new Parameter<Sprite>();
        public Parameter<int> Health { get; set; } = new Parameter<int>();
    }
}