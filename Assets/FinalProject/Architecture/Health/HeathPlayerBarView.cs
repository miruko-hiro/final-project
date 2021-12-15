using System;
using DG.Tweening;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.UI.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Health
{
    public class HeathPlayerBarView: HealthBar
    {
        [SerializeField] private Text _healthText;
        
        private HealthPlayerBarPresenter _presenter;
        private float _duration = 0.5f;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _presenter = new HealthPlayerBarPresenter(this, _gameManager);
        }

        public override void ReduceHealth(float amount, int newHealth, int maxHealth)
        {
            _healthText.text = newHealth + " / " + maxHealth;
            _healthImage.DOFillAmount(amount, _duration);
        }

        public void ChangeHealthEvent(float amount, int newHealth, int maxHealth)
        {
            _healthText.text = newHealth + " / " + maxHealth;
            _healthImage.DOFillAmount(amount, _duration);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}