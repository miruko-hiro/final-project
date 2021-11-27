using System;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
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

        private PlayerPresenter _presenter;
        private DamageTextManager _damageTextManager;
        private Transform _transform;
        
        public override Sprite Race { get => race.sprite; set => race.sprite = value; }
        public override Sprite Hair { get => hairHead.sprite; set => hairHead.sprite = value; }
        public override Sprite Beard { get => beard.sprite; set => beard.sprite = value; }
        public override Sprite HeadArmor { get => head.sprite; set => head.sprite = value; }
        public override Sprite BodyArmor { get => body.sprite; set => body.sprite = value; }
        public override Sprite PantsArmor { get => pants.sprite; set => pants.sprite = value; }
        public override Sprite BootsArmor { get => boots.sprite; set => boots.sprite = value; }
        public override Sprite RightHand { get => rightHand.sprite; set => rightHand.sprite = value; }
        public override Sprite LeftHand { get => leftHand.sprite; set => leftHand.sprite = value; }

        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser, 
            DamageTextManager damageTextManager)
        {
            _presenter = new PlayerPresenter(this, gameManager, dispenser);
            _damageTextManager = damageTextManager;
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public override void TakeHit(int damage)
        {
            OnTakeDamageEvent?.Invoke(damage);
        }

        public override void ShowReceivedDamage(int damage)
        {
            _damageTextManager.ShowDamageToEnemy(_transform.position, damage);
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