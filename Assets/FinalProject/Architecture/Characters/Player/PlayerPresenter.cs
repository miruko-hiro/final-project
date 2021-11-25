using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;

namespace FinalProject.Architecture.Characters.Player
{
    public class PlayerPresenter
    {
        private readonly Humanoid _view;
        private readonly PlayerRaceInteractor _raceInteractor;
        private readonly PlayerHairInteractor _hairInteractor;
        private readonly PlayerBeardInteractor _beardInteractor;
        private readonly PlayerHeadInteractor _headInteractor;
        private readonly PlayerBodyInteractor _bodyInteractor;
        private readonly PlayerPantsInteractor _pantsInteractor;
        private readonly PlayerBootsInteractor _bootsInteractor;
        private readonly PlayerShieldInteractor _shieldInteractor;
        private readonly PlayerWeaponInteractor _weaponInteractor;
        private readonly PlayerHealthInspector _healthInspector;
        private AppearanceIssuanceSystem _dispenser;

        public PlayerPresenter(Humanoid view, GameManager gameManager, AppearanceIssuanceSystem dispenser)
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
            _healthInspector = gameManager.GetInteractor<PlayerHealthInspector>();
            OnOpen();
        }

        private void LoadData()
        {
            SetRace(_raceInteractor.GetRaceProperties());
            SetHair(_hairInteractor.GetHairProperties());
            SetBeard(_beardInteractor.GetBeardProperties());
            
            SetHeadArmor(_headInteractor.GetHeadProperties());
            SetBodyArmor(_bodyInteractor.GetBodyProperties());
            SetPantsArmor(_pantsInteractor.GetPantsProperties());
            SetBootsArmor(_bootsInteractor.GetBootsProperties());

            SetLeftHand(_shieldInteractor.GetShieldProperties());
            SetRightHand(_weaponInteractor.GetWeaponProperties());
        }

        private void SaveData()
        {
            
        }

        private void OnOpen()
        {
            LoadData();

            _raceInteractor.ChangeRaceEvent += SetRace;
            _hairInteractor.ChangeHairEvent += SetHair;
            _beardInteractor.ChangeBeardEvent += SetBeard;
            _headInteractor.ChangeHeadEvent += SetHeadArmor;
            _bodyInteractor.ChangeBodyEvent += SetBodyArmor;
            _pantsInteractor.ChangePantsEvent += SetPantsArmor;
            _bootsInteractor.ChangeBootsEvent += SetBootsArmor;
            _shieldInteractor.ChangeShieldEvent += SetLeftHand;
            _weaponInteractor.ChangeWeaponEvent += SetRightHand;
        }

        private void OnClose()
        {
            SaveData();

            _raceInteractor.ChangeRaceEvent -= SetRace;
            _hairInteractor.ChangeHairEvent -= SetHair;
            _beardInteractor.ChangeBeardEvent -= SetBeard;
            _headInteractor.ChangeHeadEvent -= SetHeadArmor;
            _bodyInteractor.ChangeBodyEvent -= SetBodyArmor;
            _pantsInteractor.ChangePantsEvent -= SetPantsArmor;
            _bootsInteractor.ChangeBootsEvent -= SetBootsArmor;
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

        private void SetHeadArmor(HeadProperties headProperties)
        {
            _view.HeadArmor = _dispenser.GetHeadArmor(headProperties);
        }

        private void SetBodyArmor(BodyProperties bodyProperties)
        {
            _view.BodyArmor = _dispenser.GetBodyArmor(bodyProperties);
        }

        private void SetPantsArmor(PantsProperties pantsProperties)
        {
            _view.PantsArmor = _dispenser.GetPantsArmor(pantsProperties);
        }

        private void SetBootsArmor(BootsProperties bootsProperties)
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

        ~PlayerPresenter()
        {
            OnClose();
        }
    }
}