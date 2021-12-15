using DG.Tweening;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Teleport
{
    public class TeleportAnimation : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _spriteRenderer.DOFade(1f, 2f).From(0f);
        }
    }
}
