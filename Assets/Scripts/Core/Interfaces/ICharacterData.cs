using Core.Parameters;
using Template.Creatures.Types;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICharacterData
    {
        public HumanoidRace HumanoidRace { get; set; }
        public HumanoidGender HumanoidGender { get; set; }
        public Parameter<Sprite> HumanoidRaceSprite { get; set; }
        public Parameter<Sprite> HairSprite { get; set; }
        public Parameter<Sprite> BeardSprite { get; set; }
        public Parameter<Sprite> HeadArmorSprite { get; set; }
        public Parameter<Sprite> BodyArmorSprite { get; set; }
        public Parameter<Sprite> PantsArmorSprite { get; set; }
        public Parameter<Sprite> BootsArmorSprite { get; set; }
        public Parameter<Sprite> LeftHandSprite { get; set; }
        public Parameter<Sprite> RightHandSprite { get; set; }
        public Parameter<int> Health { get; set; }

    }
}