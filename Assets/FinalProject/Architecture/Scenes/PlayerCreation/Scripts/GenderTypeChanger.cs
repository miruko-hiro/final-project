using FinalProject.Architecture.Characters.Player;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Player.Scripts;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI.Selectors;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts
{
    public class GenderTypeChanger
    {
        private readonly PlayerRaceInteractor _raceInteractor;
        private readonly PlayerBodyInteractor _bodyInteractor;
        private readonly PlayerCreationView _player;
        private readonly AppearanceIssuanceSystem _dispenser;

        public GenderTypeChanger(GameManager gameManager, PlayerCreationView player, AppearanceIssuanceSystem dispenser)
        {
            _raceInteractor = gameManager.GetInteractor<PlayerRaceInteractor>();
            _bodyInteractor = gameManager.GetInteractor<PlayerBodyInteractor>();
            _player = player;
            _dispenser = dispenser;
        }


        public void Change(SelectionType type)
        {
            if (_raceInteractor.RaceProperties.Gender == HumanoidGender.Female)
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
            var raceProperties = _raceInteractor.RaceProperties;
            raceProperties.Gender = gender;
            _raceInteractor.RaceProperties = raceProperties;
            _player.Race = _dispenser.GetHumanoid(raceProperties);
        }

        private void SetBodyArmor(int index, ArmorType type)
        {
            var bodyArmorProperties = _bodyInteractor.ArmorProperties;
            bodyArmorProperties.ArmorType = type;
            bodyArmorProperties.SpriteIndex = index;
            _bodyInteractor.ArmorProperties = bodyArmorProperties;
            _player.BodyArmor = _dispenser.GetBodyArmor(bodyArmorProperties);
        }
    }
}