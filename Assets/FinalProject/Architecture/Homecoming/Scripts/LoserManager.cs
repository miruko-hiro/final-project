using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Homecoming.Scripts
{
    public class LoserManager : MonoBehaviour
    {
        [SerializeField] private GameObject _loserPanel;
        private GameManager _gameManager;
        private PlayerHealthInspector _inspector;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _inspector = _gameManager.GetInteractor<PlayerHealthInspector>();
            _inspector.ReduceHealthEvent += ReduceHealth;
        }

        private void ReduceHealth(int health)
        {
            if(health > 0) return;
            _loserPanel.SetActive(true);
        }

        private void OnDestroy()
        {
            _inspector.ReduceHealthEvent -= ReduceHealth;
        }
    }
}
