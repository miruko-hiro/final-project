﻿using FinalProject.Architecture.Characters.Player;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI.Selectors;
using Template.Creatures;
using Template.Creatures.Appearance;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts
{
    public class GenderTypeChanger
    {
        private readonly PlayerData _pData;
        private readonly Humanoid _player;
        private readonly AppearanceIssuanceSystem _dispenser;

        public GenderTypeChanger(PlayerData pData, Humanoid player, AppearanceIssuanceSystem dispenser)
        {
            _pData = pData;
            _player = player;
            _dispenser = dispenser;
        }


        public void Change(SelectionType type)
        {
            if (_pData.HumanoidGender == HumanoidGender.Female)
            {
                DoWhenPerv();
            }
            else
            {
                DoWhenNext();
            }
        }
        
        private void DoWhenPerv()
        {
            SetGenderType(HumanoidGender.Male);
            SetBodyArmor(0, ArmorType.Light);
        }

        private void DoWhenNext()
        {
            SetGenderType(HumanoidGender.Female);
            SetBodyArmor(1, ArmorType.Light);
        }

        private void SetGenderType(HumanoidGender gender)
        {
            _pData.HumanoidGender = gender;
            _pData.HumanoidRaceSprite.Value =
                _dispenser.GetHumanoid(0, _pData.HumanoidRace, _pData.HumanoidGender);
            _player.Race = _pData.HumanoidRaceSprite.Value;
        }

        private void SetBodyArmor(int index, ArmorType type)
        {
            _pData.BodyArmorSprite.Value = _dispenser.GetBodyArmor(index, type);
            _player.BodyArmor = _pData.BodyArmorSprite.Value;
        }
    }
}