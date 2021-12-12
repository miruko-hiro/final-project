﻿using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class BattleSpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private BarrelSpawner _barrelSpawner;
        [SerializeField] private TrapSpawner _trapSpawner;

        private void Awake()
        {
            var grid = new SpawnGrid().GetGrid(Vector2.zero);
            
            Debug.Log("grid count " + grid.Count);
            EnemyGeneration(grid);

            Debug.Log("grid count " + grid.Count);
            TrapGeneration(grid);

            Debug.Log("grid count " + grid.Count);
            BarrelGeneration(grid);
            
            Debug.Log("grid count " + grid.Count);
        }

        private void EnemyGeneration(List<Vector2> grid)
        {
            var random = new Random();
            var numberOfEnemyPrefabs = _enemySpawner.NumberOfEnemyPrefabs;

            for (int i = 0; i < 3; i++)
            {
                var randomIndexPosition = random.Next(0, grid.Count);
                _enemySpawner.Generation(random.Next(0, numberOfEnemyPrefabs), grid[randomIndexPosition], 5, 1);
                grid.RemoveAt(randomIndexPosition);
            }
        }

        private void TrapGeneration(List<Vector2> grid)
        {
            var random = new Random();
            var numberOfTrapPrefabs = _trapSpawner.NumberOfTrapPrefabs;

            for (int i = 0; i < 3; i++)
            {
                var randomIndexPosition = random.Next(0, grid.Count);
                _trapSpawner.Generation(random.Next(0, numberOfTrapPrefabs), grid[randomIndexPosition], 5);
                grid.RemoveAt(randomIndexPosition);
            }
        }

        private void BarrelGeneration(List<Vector2> grid)
        {
            var random = new Random();
            var numberOfBarrelPrefabs = _barrelSpawner.NumberOfBarrelPrefabs;

            for (int i = 0; i < 6; i++)
            {
                var randomIndexPosition = random.Next(0, grid.Count);
                _barrelSpawner.Generation(random.Next(0, numberOfBarrelPrefabs), grid[randomIndexPosition]);
                grid.RemoveAt(randomIndexPosition);
            }
        }
    }
}