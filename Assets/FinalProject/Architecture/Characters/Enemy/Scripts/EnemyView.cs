using System;
using DG.Tweening;
using FinalProject.Architecture.Characters.Enemy.UtilityAI;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.DamageText;
using FinalProject.Architecture.DamageText.Scripts;
using FinalProject.Architecture.Items.Scripts;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using FinalProject.Architecture.Settings.SoundEffects;
using Pathfinding;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace FinalProject.Architecture.Characters.Enemy.Scripts
{
    public class EnemyView: MonoBehaviour, IAttackTrigger
    {
        [SerializeField] private ParticleSystem _deathEffect;
        [SerializeField] private EnemyAI _enemyAI;
        [SerializeField] private CharacterSound characterSound;
        [SerializeField] private CharacterSound _deathSound;
        public event Action<int> OnTakeDamageEvent;

        private Transform _transform;
        private Collider2D _collider;
        private EnemyPresenter _presenter;
        private ItemManager _itemManager;
        private DamageTextManager _damageTextManager;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _collider = GetComponent<CircleCollider2D>();
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
            characterSound.SoundEffect();
            OnTakeDamageEvent?.Invoke(damage);
        }

        public void ShowReceivedDamage(int damage)
        {
            _damageTextManager.ShowDamageToEnemy(_transform.position, damage);
        }

        public void Die()
        {
            _enemyAI.IsEnable = false;
            _collider.enabled = false;
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
                    _deathSound.SoundEffect();
                    _itemManager.ThrowItem(transform.position);
                    _deathEffect.transform.SetParent(null);
                    _deathEffect.Emit(15);
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