using System;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using Zenject;
using Random =  UnityEngine.Random;

namespace FinalProject.Architecture.Characters.Enemy
{
    public class GeneratorEnemyData
    {
        private AppearanceIssuanceSystem _dispenser;
        
        [Inject]
        private GeneratorEnemyData(AppearanceIssuanceSystem dispenser)
        {
            _dispenser = dispenser;
        }
        
        public EnemyData GetData(int level) => level switch
        {
            1 => GetDataForEnemyLevel1(),
            _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
        };

        private EnemyData GetDataForEnemyLevel1()
        {
            EnemyData data = GetBaseData();

            data.HeadArmorSprite.Value =
                _dispenser.GetHeadArmor(new HeadProperties(ArmorType.Light, Random.Range(0, Limits.HeadLightArmorIndex - 1), 0));
            data.BodyArmorSprite.Value =
                _dispenser.GetBodyArmor(new BodyProperties(ArmorType.Light, Random.Range(0,Limits.BodyLightArmorIndex - 1), 0));
            data.PantsArmorSprite.Value = _dispenser.GetPantsArmor(new PantsProperties(Random.Range(0,Limits.PantsArmorIndex - 1), 0));
            data.BootsArmorSprite.Value = _dispenser.GetBootsArmor(new BootsProperties(Random.Range(0,Limits.BootsArmorIndex - 1), 0));
            data.RightHandSprite.Value = _dispenser.GetWeapon(new WeaponProperties(WeaponType.Sword, MagicType.None, Random.Range(0, 2), 1));

            return data;
        }

        private EnemyData GetBaseData()
        {
            EnemyData data = new EnemyData();
            
            data.Health.Value = 5;
            data.HumanoidRace = HumanoidRace.Human;
            data.HumanoidGender = Random.Range(0,1) == 0 ? HumanoidGender.Male : HumanoidGender.Female;
            data.HumanoidRaceSprite.Value =
                _dispenser.GetHumanoid(new HumanoidRaceProperties(data.HumanoidRace, data.HumanoidGender, Random.Range(0,Limits.HumanIndex - 1)));
            
            Array values = Enum.GetValues(typeof(HairColor));
            HairColor hairColor = (HairColor) values.GetValue(Random.Range(0,values.Length - 1));

            data.HairSprite.Value = data.HumanoidGender ==
                                    HumanoidGender.Male
                ? _dispenser.GetHairHead(new HairProperties(hairColor, HairLength.Short,Random.Range(0,Limits.ShortHairIndex - 1)))
                : _dispenser.GetHairHead(new HairProperties(hairColor, HairLength.Long,Random.Range(0,Limits.LongHairIndex - 1)));
            
            
            values = Enum.GetValues(typeof(HairColor));
            hairColor = (HairColor) values.GetValue(Random.Range(0,values.Length - 1));

            data.BeardSprite.Value = data.HumanoidGender == HumanoidGender.Male
                ? Random.Range(0, 1) == 0
                    ? _dispenser.GetBeard(new BeardProperties(hairColor, BeardLength.Beard, Random.Range(0,Limits.BeardIndex - 1)))
                    : _dispenser.GetBeard(new BeardProperties(hairColor, BeardLength.Mustache, Random.Range(0,Limits.BeardIndex - 1)))
                : null;

            return data;
        }
    }
}