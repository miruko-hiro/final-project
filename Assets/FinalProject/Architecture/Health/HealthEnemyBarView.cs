using System;
using DG.Tweening;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.UI.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Health
{
    public class HealthEnemyBarView : HealthBar
    {
        private HealthEnemyBarPresenter _presenter;
        private float _duration = 0.5f;
        private TranslatorWorldToScreen _translator;
        private Vector3 _savePosition;
        private Transform _transformOwn;
        private RectTransform _rectTransform;
        private RectTransform _rectTransformParent;
        private Camera _camera;

        private void Awake()
        {
            _translator = new TranslatorWorldToScreen();
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Initialize(HealthEnemyBarPresenter presenter, Transform transformOwn, Camera mainCamera, RectTransform rectTransform)
        {
            _rectTransformParent = rectTransform;
            _presenter = presenter;
            _transformOwn = transformOwn;
            _camera = mainCamera;
            SetPosition(transformOwn.position);
        }

        public override void ReduceHealth(float amount)
        {
            _healthImage.DOFillAmount(amount, _duration);
        }

        private void Update()
        {
            if (_savePosition == _transformOwn.position) return;
            SetPosition(_transformOwn.position);
            
        }

        private void SetPosition(Vector3 newPosition)
        {
            _rectTransform.anchoredPosition = _translator.WorldToScreenSpace(newPosition + Vector3.up, _camera, _rectTransformParent);
            _savePosition = newPosition;
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}