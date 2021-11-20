using System;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using Template.Creatures.Appearance;
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
        
        public ICharacterData GetData(int level) => level switch
        {
            1 => GetDataForEnemyLevel1(),
            _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
        };

        private ICharacterData GetDataForEnemyLevel1()
        {
            ICharacterData data = GetBaseData();

            data.HeadArmorSprite.Value =
                _dispenser.GetHeadArmor(Random.Range(0, Limits.HeadLightArmorIndex - 1), ArmorType.Light);
            data.BodyArmorSprite.Value =
                _dispenser.GetBodyArmor(Random.Range(0,Limits.BodyLightArmorIndex - 1), ArmorType.Light);
            data.PantsArmorSprite.Value = _dispenser.GetPantsArmor(Random.Range(0,Limits.PantsArmorIndex - 1));
            data.BootsArmorSprite.Value = _dispenser.GetBootsArmor(Random.Range(0,Limits.BootsArmorIndex - 1));
            data.RightHandSprite.Value = _dispenser.GetWeapon(Random.Range(0, 2), WeaponType.Sword);

            return data;
        }

        private ICharacterData GetBaseData()
        {
            EnemyData data = new EnemyData();
            
            data.Health.Value = 5;
            data.HumanoidRace = HumanoidRace.Human;
            data.HumanoidGender = Random.Range(0,1) == 0 ? HumanoidGender.Male : HumanoidGender.Female;
            data.HumanoidRaceSprite.Value =
                _dispenser.GetHumanoid(Random.Range(0,Limits.HumanIndex - 1), data.HumanoidRace, data.HumanoidGender);
            
            Array values = Enum.GetValues(typeof(HairColor));
            HairColor hairColor = (HairColor) values.GetValue(Random.Range(0,values.Length - 1));

            data.HairSprite.Value = data.HumanoidGender ==
                                    HumanoidGender.Male
                ? _dispenser.GetHairHead(Random.Range(0,Limits.ShortHairIndex - 1), HairLength.Short, hairColor)
                : _dispenser.GetHairHead(Random.Range(0,Limits.LongHairIndex - 1), HairLength.Long, hairColor);
            
            
            values = Enum.GetValues(typeof(HairColor));
            hairColor = (HairColor) values.GetValue(Random.Range(0,values.Length - 1));

            data.BeardSprite.Value = data.HumanoidGender == HumanoidGender.Male
                ? Random.Range(0, 1) == 0
                    ? _dispenser.GetBeard(Random.Range(0,Limits.BeardIndex - 1), BeardLength.Beard, hairColor)
                    : _dispenser.GetBeard(Random.Range(0,Limits.BeardIndex - 1), BeardLength.Mustache, hairColor)
                : null;

            return data;
        }
    }
}