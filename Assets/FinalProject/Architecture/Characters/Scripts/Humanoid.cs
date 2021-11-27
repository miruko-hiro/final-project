using System;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts
{
    public abstract class Humanoid : MonoBehaviour
    {
        public abstract event Action<int> OnTakeDamageEvent;
        public abstract event Action<int> OnAddMoneyEvent;
        
        [Space(10)] 
        [SerializeField] protected SpriteRenderer race;
        [Space(10)]
        [SerializeField] protected SpriteRenderer hairHead;
        [SerializeField] protected SpriteRenderer beard;
        [Space(10)]
        [SerializeField] protected SpriteRenderer head;
        [SerializeField] protected SpriteRenderer body;
        [SerializeField] protected SpriteRenderer pants;
        [SerializeField] protected SpriteRenderer boots;
        [Space(10)]
        [SerializeField] protected SpriteRenderer rightHand;
        [SerializeField] protected SpriteRenderer leftHand;
        
        public abstract Sprite Race { get; set; }

        public abstract Sprite Hair { get; set; }
        public abstract Sprite Beard { get; set; }
        public abstract Sprite HeadArmor { get; set; }
        public abstract Sprite BodyArmor { get; set; }
        public abstract Sprite PantsArmor { get; set; }
        public abstract Sprite BootsArmor { get; set; }
        public abstract Sprite RightHand { get; set; }
        public abstract Sprite LeftHand { get; set; }

        public abstract void TakeHit(int damage);

        public abstract void ShowReceivedDamage(int damage);

        public abstract void Die();

        public abstract void AddMoney(int money);
    }
}
