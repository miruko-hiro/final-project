using Template.Creatures.Types;

namespace Core.Player
{
    public class PlayerData
    {
        public HumanoidRace HumanoidRace { get; set; } = HumanoidRace.Orc;
        public int IndexHumanoidRace { get; set; } = 0;
        public HumanoidGender HumanoidGender { get; set; } = HumanoidGender.Male;

        public HairLength HairLength { get; set; } = HairLength.Short;
        public HairColor HairColor { get; set; } = HairColor.Black;
        public int IndexHair { get; set; } = 0;

        public BeardLength BeardLength { get; set; } = BeardLength.Mustache;
        public HairColor BeardColor { get; set; } = HairColor.Black;
        public int IndexBeard { get; set; } = 0;

        public ArmorType BodyArmorType { get; set; } = ArmorType.Light;
        public int IndexBodyArmor { get; set; } = 0;
    }
}