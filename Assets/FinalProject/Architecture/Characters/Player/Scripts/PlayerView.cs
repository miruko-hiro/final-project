using System;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Systems.Attack;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.DamageText.Scripts;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Player.Scripts
{
    public class PlayerView : Humanoid
    {
        public override event Action<int> OnTakeDamageEvent;
        public override event Action<int> OnAddMoneyEvent;

        [Space(10)] [SerializeField] private GameObject _meleeAttackSystem;
        [SerializeField] private GameObject _staffAttackSystem;
        [SerializeField] private GameObject _bowAttackSystem;

        private PlayerPresenter _presenter;
        private DamageTextManager _damageTextManager;
        private Transform _transform;
        private GameManager _gameManager;
        private AppearanceIssuanceSystem _dispenser;

        public override Sprite Race
        {
            get => race.sprite;
            set => race.sprite = value;
        }

        public override Sprite Hair
        {
            get => hairHead.sprite;
            set => hairHead.sprite = value;
        }

        public override Sprite Beard
        {
            get => beard.sprite;
            set => beard.sprite = value;
        }

        public override Sprite HeadArmor
        {
            get => head.sprite;
            set => head.sprite = value;
        }

        public override Sprite BodyArmor
        {
            get => body.sprite;
            set => body.sprite = value;
        }

        public override Sprite PantsArmor
        {
            get => pants.sprite;
            set => pants.sprite = value;
        }

        public override Sprite BootsArmor
        {
            get => boots.sprite;
            set => boots.sprite = value;
        }

        public override Sprite RightHand
        {
            get => rightHand.sprite;
            set => rightHand.sprite = value;
        }

        public override Sprite LeftHand
        {
            get => leftHand.sprite;
            set => leftHand.sprite = value;
        }

        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser,
            DamageTextManager damageTextManager)
        {
            _gameManager = gameManager;
            _dispenser = dispenser;
            _damageTextManager = damageTextManager;
        }

        private void Awake()
        {
            _presenter = new PlayerPresenter(this, _gameManager, _dispenser);
            _transform = GetComponent<Transform>();
        }

        public override void TakeHit(int damage)
        {
            OnTakeDamageEvent?.Invoke(damage);
        }

        public override void ShowReceivedDamage(int damage)
        {
            _damageTextManager.ShowDamageToPlayer(_transform.position, damage);
        }

        public void SelectMeleeAttackSystem()
        {
            if(!CheckAttackSystem()) return;
            if (_staffAttackSystem.activeInHierarchy)
                _staffAttackSystem.SetActive(false);
            if (_bowAttackSystem.activeInHierarchy)
                _bowAttackSystem.SetActive(false);
            _meleeAttackSystem.SetActive(true);
        }

        public void SelectStaffAttackSystem(MagicType type)
        {
            if(!CheckAttackSystem()) return;
            if (_meleeAttackSystem.activeInHierarchy)
                _meleeAttackSystem.SetActive(false);
            if (_bowAttackSystem.activeInHierarchy)
                _bowAttackSystem.SetActive(false);
            _staffAttackSystem.SetActive(true);
            _staffAttackSystem.GetComponent<StaffAttackSystem>().MagicType = type;
        }

        public void SelectBowAttackSystem()
        {
            if(!CheckAttackSystem()) return;
            if (_staffAttackSystem.activeInHierarchy)
                _staffAttackSystem.SetActive(false);
            if (_meleeAttackSystem.activeInHierarchy)
                _meleeAttackSystem.SetActive(false);
            _bowAttackSystem.SetActive(true);
        }

        private bool CheckAttackSystem()
        {
            if (_meleeAttackSystem == null || _staffAttackSystem == null || _bowAttackSystem == null) return false;
            else return true;
        }

        public override void Die()
        {
            
        }

        public override void AddMoney(int money)
        {
            OnAddMoneyEvent?.Invoke(money);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}