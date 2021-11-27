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

        private PlayerLevelInteractor _levelInteractor;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _levelInteractor = gameManager.GetInteractor<PlayerLevelInteractor>();
        }
        
        private void Awake()
        {
            _coinPool = new PoolMono<Item>(_coinPrefab, 2, transform);
        }

        public void ThrowItem(Vector2 position)
        {
            var pool = SelectItem(_levelInteractor.GetLevel());
            var item = pool.GetFreeElement();
            item.transform.position = position;
            item.Jump();
        }

        private PoolMono<Item> SelectItem(int level)
        {
            return level switch
            {
                0 => SelectItemLevel0(),
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
        }

        private PoolMono<Item> SelectItemLevel0()
        {
            return _coinPool;
        }
    }
}
