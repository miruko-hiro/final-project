using System.Collections.Generic;
using FinalProject.Architecture.Characters.Enemy.Health;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Range(1, 2)] [SerializeField] private int _level;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private GameObject _healthEnemyBar;
        [SerializeField] private List<Vector3> _positions;
        [SerializeField] private Transform _target;
        private List<EnemyPresenter> _presenters;
        private List<HealthEnemyBarPresenter> _healthPresenters;
        private GeneratorEnemyData _generator;

        [Inject]
        private void Construct(GeneratorEnemyData generator)
        {
            _generator = generator;
        }
        
        private void Awake()
        {
            _presenters = new List<EnemyPresenter>();
            _healthPresenters = new List<HealthEnemyBarPresenter>();
            
            foreach (var pos in _positions)
            {
                var enemy = Instantiate(_enemyPrefab, pos, Quaternion.identity);
                enemy.GetComponent<AIDestinationSetter>().target = _target;
                var data = _generator.GetData(_level);
                _presenters.Add(new EnemyPresenter(enemy.GetComponentInChildren<EnemyView>(), data));
                
                _healthPresenters.Add(new HealthEnemyBarPresenter(Instantiate(_healthEnemyBar).GetComponent<HealthEnemyBarView>(), data));
            }
        }

        private void OnDestroy()
        {
            _presenters.Clear();
            _healthPresenters.Clear();
        }
    }
}