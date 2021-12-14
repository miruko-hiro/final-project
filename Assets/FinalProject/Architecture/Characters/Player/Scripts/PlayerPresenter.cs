using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Hair;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;

namespace FinalProject.Architecture.Characters.Player.Scripts
{
    public class PlayerPresenter
    {
        private readonly PlayerView _view;
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
        private readonly PlayerAttackInteractor _attackInteractor;
        private readonly PlayerMoneyInteractor _moneyInteractor;
        private readonly AppearanceIssuanceSystem _dispenser;

        public PlayerPresenter(PlayerView view, GameManager gameManager, AppearanceIssuanceSystem dispenser)
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
            _attackInteractor = gameManager.GetInteractor<PlayerAttackInteractor>();
            _moneyInteractor = gameManager.GetInteractor<PlayerMoneyInteractor>();

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
            SetHealth(_shieldInteractor.ShieldProperties);
            
            SetRightHand(_weaponInteractor.WeaponProperties);
            SetAttack(_weaponInteractor.WeaponProperties);
        }

        private void OnOpen()
        {
            LoadData();

            _raceInteractor.ChangeRaceEvent += SetRace;
            _hairInteractor.ChangeHairEvent += SetHair;
            _beardInteractor.ChangeBeardEvent += SetBeard;
            
            _headInteractor.ChangeArmorEvent += SetHeadArmor;
            _headInteractor.ChangeArmorEvent += SetHealth;
            
            _bodyInteractor.ChangeArmorEvent += SetBodyArmor;
            _bodyInteractor.ChangeArmorEvent += SetHealth;
            
            _pantsInteractor.ChangeArmorEvent += SetPantsArmor;
            _pantsInteractor.ChangeArmorEvent += SetHealth;
            
            _bootsInteractor.ChangeArmorEvent += SetBootsArmor;
            _bootsInteractor.ChangeArmorEvent += SetHealth;
            
            _shieldInteractor.ChangeShieldEvent += SetLeftHand;
            _shieldInteractor.ChangeShieldEvent += SetHealth;
            
            _weaponInteractor.ChangeWeaponEvent += SetRightHand;
            _weaponInteractor.ChangeWeaponEvent += SetAttack;
            
            _healthInspector.ChangeHealthEvent += Die;

            _view.OnTakeDamageEvent += ChangeHealth;
            _view.OnAddMoneyEvent += AddMoney;

        }

        private void OnClose()
        {
            _raceInteractor.ChangeRaceEvent -= SetRace;
            _hairInteractor.ChangeHairEvent -= SetHair;
            _beardInteractor.ChangeBeardEvent -= SetBeard;
            
            _headInteractor.ChangeArmorEvent -= SetHeadArmor;
            _headInteractor.ChangeArmorEvent -= SetHealth;
            
            _bodyInteractor.ChangeArmorEvent -= SetBodyArmor;
            _bodyInteractor.ChangeArmorEvent -= SetHealth;
            
            _pantsInteractor.ChangeArmorEvent -= SetPantsArmor;
            _pantsInteractor.ChangeArmorEvent -= SetHealth;
            
            _bootsInteractor.ChangeArmorEvent -= SetBootsArmor;
            _bootsInteractor.ChangeArmorEvent -= SetHealth;
            
            _shieldInteractor.ChangeShieldEvent -= SetLeftHand;
            _shieldInteractor.ChangeShieldEvent -= SetHealth;
            
            _weaponInteractor.ChangeWeaponEvent -= SetRightHand;
            _weaponInteractor.ChangeWeaponEvent -= SetAttack;
            
            _healthInspector.ChangeHealthEvent -= Die;

            _view.OnTakeDamageEvent -= ChangeHealth;
            _view.OnAddMoneyEvent -= AddMoney;
        }

        private void AddMoney(int money)
        {
            _moneyInteractor.Money += money;
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
            if (weaponProperties.WeaponType == WeaponType.Staff) 
                _view.SelectStaffAttackSystem(weaponProperties.MagicType);
            else if(weaponProperties.WeaponType == WeaponType.Bow)
                _view.SelectBowAttackSystem();
            else
                _view.SelectMeleeAttackSystem();

            _view.RightHand = _dispenser.GetWeapon(weaponProperties);
        }

        private void SetLeftHand(ShieldProperties shieldProperties)
        {
            _view.LeftHand = _dispenser.GetShield(shieldProperties);
        }

        private void SetHealth(ShieldProperties shieldProperties)
        {
            _healthInspector.Health = 5 + 
                                      shieldProperties.ProtectionScore +
                                      _bodyInteractor.ArmorProperties.ProtectionScore + 
                                      _headInteractor.ArmorProperties.ProtectionScore + 
                                      _bootsInteractor.ArmorProperties.ProtectionScore + 
                                      _pantsInteractor.ArmorProperties.ProtectionScore;
        }

        private void SetHealth(ArmorProperties armorProperties)
        {
            _healthInspector.Health = 5 +
                _shieldInteractor.ShieldProperties.ProtectionScore +
                (armorProperties.ItemType == ItemType.Body ? armorProperties.ProtectionScore : _bodyInteractor.ArmorProperties.ProtectionScore) + 
                (armorProperties.ItemType == ItemType.Head ? armorProperties.ProtectionScore : _headInteractor.ArmorProperties.ProtectionScore) + 
                (armorProperties.ItemType == ItemType.Boots ? armorProperties.ProtectionScore : _bootsInteractor.ArmorProperties.ProtectionScore) + 
                (armorProperties.ItemType == ItemType.Pants ? armorProperties.ProtectionScore : _pantsInteractor.ArmorProperties.ProtectionScore);
        }

        private void SetAttack(WeaponProperties weaponProperties)
        {
            _attackInteractor.Attack = weaponProperties.AttackScore;
        }
        
        private void Die(int health)
        {
            if (health > 0) return;
            _view.Die();
        }

        private void ChangeHealth(int damage)
        {
            _healthInspector.Health -= damage;
            _view.ShowReceivedDamage(damage);
        }

        ~PlayerPresenter()
        {
            OnClose();
        }
    }
}