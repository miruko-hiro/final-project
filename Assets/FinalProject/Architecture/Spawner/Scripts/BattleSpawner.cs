using System.Collections.Generic;
using FinalProject.Architecture.Scenes.FreeZone.Scripts.Teleport;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class BattleSpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private BarrelSpawner _barrelSpawner;
        [SerializeField] private TrapSpawner _trapSpawner;
        [SerializeField] private TeleportZone _teleportZone;
        private SpawnGrid _spawnGrid;
        private List<Vector2> _grid;
        private int _level;

        private void Awake()
        {
            _spawnGrid = new SpawnGrid();
            _teleportZone.OnEnterZone += AddLevel;
            
            AddLevel();
        }

        private void AddLevel()
        {
            _level += 1;
            Generation();
        }

        private void Generation()
        {
            _grid = _spawnGrid.GetGrid(Vector2.zero);
            if (_level == 1)
            {
                var numberOfEnemyPrefabs = _enemySpawner.NumberOfEnemyPrefabs;
                _enemySpawner.Count = 1;
                _enemySpawner.Generation(Random.Range(0, numberOfEnemyPrefabs - 1), _grid[11], 5, 1);
                BarrelGeneration(2);
            } else if (_level == 2)
            {
                EnemyGeneration(2);
                TrapGeneration(1);
                BarrelGeneration(2);
            }
            else
            {
                EnemyGeneration(3);
                TrapGeneration(1);
                BarrelGeneration(3);
            }
        }

        private void EnemyGeneration(int count)
        {
            _enemySpawner.Count = count;
            _enemySpawner.DestroyEnemies();
            var numberOfEnemyPrefabs = _enemySpawner.NumberOfEnemyPrefabs;

            for (int i = 0; i < count; i++)
            {
                var randomIndexPosition = Random.Range(0, _grid.Count - 1);
                _enemySpawner.Generation(Random.Range(0, numberOfEnemyPrefabs - 1), _grid[randomIndexPosition], 5, 1);
                _grid.RemoveAt(randomIndexPosition);
            }
        }

        private void TrapGeneration(int count)
        {
            _trapSpawner.DestroyTraps();
            var numberOfTrapPrefabs = _trapSpawner.NumberOfTrapPrefabs;

            for (int i = 0; i < count; i++)
            {
                var randomIndexPosition = Random.Range(0, _grid.Count - 1);
                _trapSpawner.Generation(Random.Range(0, numberOfTrapPrefabs - 1), _grid[randomIndexPosition], 5);
                _grid.RemoveAt(randomIndexPosition);
            }
        }

        private void BarrelGeneration(int count)
        {
            _barrelSpawner.DestroyBarrels();
            var numberOfBarrelPrefabs = _barrelSpawner.NumberOfBarrelPrefabs;

            for (int i = 0; i < count; i++)
            {
                var randomIndexPosition = Random.Range(0, _grid.Count - 1);
                _barrelSpawner.Generation(Random.Range(0, numberOfBarrelPrefabs - 1), _grid[randomIndexPosition]);
                _grid.RemoveAt(randomIndexPosition);
            }
        }

        private void OnDestroy()
        {
            _teleportZone.OnEnterZone -= AddLevel;
        }
    }
}