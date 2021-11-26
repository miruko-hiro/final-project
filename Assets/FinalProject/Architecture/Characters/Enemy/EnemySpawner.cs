using System.Collections.Generic;
using FinalProject.Architecture.Health;
using Pathfinding;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemyPrefabs;
        [SerializeField] private List<Vector3> _positions;
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _healthBarPrefab;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Camera _camera;
        
        private void Awake()
        {
            for (var i = 0; i < _enemyPrefabs.Count; i++)
            {
                var enemyData = new EnemyData {Health = {Value = 5}};
                var enemy = Instantiate(_enemyPrefabs[i], _positions[i], Quaternion.identity);
                enemy.GetComponent<AIDestinationSetter>().target = _target;
                
                var enemyView = enemy.GetComponent<EnemyView>();
                var enemyPresenter = new EnemyPresenter(enemyView, enemyData);
                enemyView.Initialize(enemyPresenter);
                
                var healthBar = Instantiate(_healthBarPrefab, _canvas.transform).GetComponent<HealthEnemyBarView>();
                var healthBarPresenter = new HealthEnemyBarPresenter(healthBar, enemyData);
                healthBar.Initialize(healthBarPresenter, enemy.GetComponent<Transform>(), _camera, _canvas.GetComponent<RectTransform>());
            }
        }
    }
}