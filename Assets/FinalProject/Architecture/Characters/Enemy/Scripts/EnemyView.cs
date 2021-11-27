using System;
using DG.Tweening;
using FinalProject.Architecture.Characters.Enemy.UtilityAI;
using FinalProject.Architecture.DamageText;
using FinalProject.Architecture.DamageText.Scripts;
using FinalProject.Architecture.Items.Scripts;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Enemy.Scripts
{
    public class EnemyView: MonoBehaviour
    {
        [SerializeField] private EnemyAI _enemyAI;
        public event Action<int> OnTakeDamageEvent;

        private Transform _transform;
        private EnemyPresenter _presenter;
        private ItemManager _itemManager;
        private DamageTextManager _damageTextManager;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        [Inject]
        private void Construct(ItemManager itemManager, DamageTextManager damageTextManager)
        {
            _itemManager = itemManager;
            _damageTextManager = damageTextManager;
        }

        public void Initialize(EnemyPresenter presenter)
        {
            _presenter = presenter;
        }

        public void TakeHit(int damage)
        {
            OnTakeDamageEvent?.Invoke(damage);
        }

        public void ShowReceivedDamage(int damage)
        {
            _damageTextManager.ShowDamageToEnemy(_transform.position, damage);
        }

        public void Die()
        {
            _enemyAI.IsEnable = false;
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            var sequence = DOTween.Sequence();
            GetComponent<AIPath>().canMove = false;
            foreach (var spriteRenderer in spriteRenderers)
            {
                sequence.Insert(0f, spriteRenderer.DOFade(0.2f, 0.2f));
                sequence.Insert(0.2f, spriteRenderer.DOFade(1f, 0.2f));
                sequence.Insert(0.4f, spriteRenderer.DOFade(0.2f, 0.2f));
                sequence.Insert(0.6f, spriteRenderer.DOFade(1f, 0.2f));
                sequence.Insert(0.6f, spriteRenderer.DOFade(0f, 0.4f));
            }
            sequence
                .InsertCallback(1f, () =>
                {
                    _itemManager.ThrowItem(transform.position);
                    Destroy(gameObject);
                })
                .Play();
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}