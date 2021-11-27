using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Architecture.DamageText.Scripts
{
    public class DamageText : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Text _text;
        private Sequence _sequence;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            if (_sequence != null) _sequence.Restart();
            else
                _sequence = DOTween.Sequence()
                    .Insert(0f, _rectTransform.DOAnchorPosY(100f, 1f).From(Vector2.zero))
                    .Insert(0f, _text.DOFade(0f, 1f).From(1f))
                    .InsertCallback(1f, () => gameObject.SetActive(false))
                    .SetAutoKill(false);
        }

        private void OnDestroy()
        {
            _sequence?.Kill(true);
        }
    }
}
