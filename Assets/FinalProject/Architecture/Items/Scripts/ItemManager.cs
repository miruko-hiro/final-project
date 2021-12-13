using System;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Utils;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Items.Scripts
{
    public class ItemManager: MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        private PoolMono<Item> _coinPool;
        private GameManager _gameManager;

        private PlayerLevelInteractor _levelInteractor;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void Awake()
        {
            _levelInteractor = _gameManager.GetInteractor<PlayerLevelInteractor>();
            _coinPool = new PoolMono<Item>(_coinPrefab, 2, transform);
        }

        public void ThrowItem(Vector2 position)
        {
            var pool = SelectItem(_levelInteractor.Level);
            var item = pool.GetFreeElement();
            item.transform.position = position;
            item.Jump();
        }

        private PoolMono<Item> SelectItem(int level)
        {
            return level switch
            {
                1 => SelectItemLevel1(),
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
        }

        private PoolMono<Item> SelectItemLevel1()
        {
            return _coinPool;
        }
    }
}
