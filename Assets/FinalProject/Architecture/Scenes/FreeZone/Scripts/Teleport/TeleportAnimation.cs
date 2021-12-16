using DG.Tweening;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Teleport
{
    public class TeleportAnimation : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
        }

        private void OnEnable()
        {
            _collider.enabled = false;
            DOTween.Sequence()
                .Append(_spriteRenderer.DOFade(1f, 2f).From(0f))
                .AppendCallback(() => _collider.enabled = true);
        }
    }
}
