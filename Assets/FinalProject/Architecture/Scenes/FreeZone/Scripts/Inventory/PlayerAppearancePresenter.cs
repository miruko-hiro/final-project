using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory
{
    public class PlayerAppearancePresenter
    {
        private readonly PlayerAppearance _view;
        private readonly PlayerRaceInteractor _raceInteractor;
        private readonly PlayerHairInteractor _hairInteractor;
        private readonly PlayerBeardInteractor _beardInteractor;
        private readonly PlayerHeadInteractor _headInteractor;
        private readonly PlayerBodyInteractor _bodyInteractor;
        private readonly PlayerPantsInteractor _pantsInteractor;
        private readonly PlayerBootsInteractor _bootsInteractor;
        private readonly PlayerShieldInteractor _shieldInteractor;
        private readonly PlayerWeaponInteractor _weaponInteractor;
        private readonly AppearanceIssuanceSystem _dispenser;

        public PlayerAppearancePresenter(PlayerAppearance view, GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _view = view;
            _dispenser = dispenser;
            _raceInteractor = gameManager.GetInteractor<PlayerRaceInteractor>();
            _hairInteractor = gameManager.GetInteractor<PlayerHairInteractor>();
            _beardInteractor = gameManager.GetInteractor<PlayerBeardInteractor>();
            _headInteractor = gameManager.GetInteractor<PlayerHeadInteractor>();
            _bodyInteractor = gameManager.GetInteractor<PlayerBodyInteractor>();
            _pantsInteractor = gameManager.GetInteractor<PlayerPantsInteractor>();
            _bootsInteractor = gameManager.GetInteractor<PlayerBootsInteractor>();
            _shieldInteractor = gameManager.GetInteractor<PlayerShieldInteractor>();
            _weaponInteractor = gameManager.GetInteractor<PlayerWeaponInteractor>();

            OnOpen();
        }
        
        private void LoadData()
        {
            SetRace(_raceInteractor.RaceProperties);
            SetHair(_hairInteractor.HairProperties);
            SetBeard(_beardInteractor.BeardProperties);
            
            SetHeadArmor(_headInteractor.ArmorProperties);
            SetBodyArmor(_bodyInteractor.ArmorProperties);
            SetPantsArmor(_pantsInteractor.ArmorProperties);
            SetBootsArmor(_bootsInteractor.ArmorProperties);

            SetLeftHand(_shieldInteractor.ShieldProperties);
            SetRightHand(_weaponInteractor.WeaponProperties);
        }

        private void OnOpen()
        {
            LoadData();

            _raceInteractor.ChangeRaceEvent += SetRace;
            _hairInteractor.ChangeHairEvent += SetHair;
            _beardInteractor.ChangeBeardEvent += SetBeard;
            _headInteractor.ChangeArmorEvent += SetHeadArmor;
            _bodyInteractor.ChangeArmorEvent += SetBodyArmor;
            _pantsInteractor.ChangeArmorEvent += SetPantsArmor;
            _bootsInteractor.ChangeArmorEvent += SetBootsArmor;
            _shieldInteractor.ChangeShieldEvent += SetLeftHand;
            _weaponInteractor.ChangeWeaponEvent += SetRightHand;
        }
        
        

        private void OnClose()
        {
            _raceInteractor.ChangeRaceEvent -= SetRace;
            _hairInteractor.ChangeHairEvent -= SetHair;
            _beardInteractor.ChangeBeardEvent -= SetBeard;
            _headInteractor.ChangeArmorEvent -= SetHeadArmor;
            _bodyInteractor.ChangeArmorEvent -= SetBodyArmor;
            _pantsInteractor.ChangeArmorEvent -= SetPantsArmor;
            _bootsInteractor.ChangeArmorEvent -= SetBootsArmor;
            _shieldInteractor.ChangeShieldEvent -= SetLeftHand;
            _weaponInteractor.ChangeWeaponEvent -= SetRightHand;
        }
        
        private void SetRace(HumanoidRaceProperties raceProperties)
        {
            _view.Race = _dispenser.GetHumanoid(raceProperties);
        }

        private void SetHair(HairProperties hairProperties)
        {
            _view.Hair = _dispenser.GetHairHead(hairProperties);;
        }

        private void SetBeard(BeardProperties beardProperties)
        {
            _view.Beard = _dispenser.GetBeard(beardProperties);
        }

        private void SetHeadArmor(ArmorProperties headProperties)
        {
            _view.HeadArmor = _dispenser.GetHeadArmor(headProperties);
        }

        private void SetBodyArmor(ArmorProperties bodyProperties)
        {
            _view.BodyArmor = _dispenser.GetBodyArmor(bodyProperties);
        }

        private void SetPantsArmor(ArmorProperties pantsProperties)
        {
            _view.PantsArmor = _dispenser.GetPantsArmor(pantsProperties);
        }

        private void SetBootsArmor(ArmorProperties bootsProperties)
        {
            _view.BootsArmor = _dispenser.GetBootsArmor(bootsProperties);
        }

        private void SetRightHand(WeaponProperties weaponProperties)
        {
            _view.RightHand = _dispenser.GetWeapon(weaponProperties);
        }

        private void SetLeftHand(ShieldProperties shieldProperties)
        {
            _view.LeftHand = _dispenser.GetShield(shieldProperties);
        }

        ~PlayerAppearancePresenter()
        {
            OnClose();
        }
    }
}