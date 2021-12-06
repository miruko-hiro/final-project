using System;
using DG.Tweening;
using FinalProject.Architecture.Scenes.FreeZone.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.NPC.Trader.Scripts
{
    public class TraderView : MonoBehaviour
    {
        [SerializeField] private TraderDialog _traderDialog;
        public event Action<int> OnAddMoneyEvent;

        private TraderPresenter _presenter;
        private Transform _transform;
        private Vector3 _addVector = new Vector3(0.4f, 0.4f, 0f);
        private float _duration = 1f;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _presenter = new TraderPresenter();
        }

        private void OnEnable()
        {
            DOTween.Sequence()
                .Append(_transform.DOScale(_transform.localScale + _addVector, _duration))
                .Append(_transform.DOScale(_transform.localScale - _addVector, _duration))
                .SetLoops(-1, LoopType.Restart);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _traderDialog.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _traderDialog.Disable();
            }
        }
    }
}
