using System;
using DG.Tweening;
using Pathfinding;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy
{
    public class EnemyView: MonoBehaviour
    {
        public event Action<int> OnTakeDamageEvent;

        private EnemyPresenter _presenter;

        public void Initialize(EnemyPresenter presenter)
        {
            _presenter = presenter;
        }

        public void TakeHit(int damage)
        {
            OnTakeDamageEvent?.Invoke(damage);
        }

        public void Die()
        {
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
                .InsertCallback(1f, () => Destroy(gameObject))
                .Play();
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}