using System.Collections.Generic;
using FinalProject.Architecture.Characters.Enemy.Scripts;
using FinalProject.Architecture.Characters.Enemy.UtilityAI.Action;
using FinalProject.Architecture.Characters.Enemy.UtilityAI.Scorers;
using FinalProject.Architecture.Health;
using FinalProject.Architecture.Helpers.Scripts;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemyPrefabs;
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _healthBarPrefab;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Camera _camera;
        private PrefabFactory _prefabFactory;
        
        public int NumberOfEnemyPrefabs => _enemyPrefabs.Count;

        [Inject]
        private void Construct(PrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
        }

        public void Generation(int indexEnemy, Vector2 position, int health, int damage)
        {
            var enemyData = new EnemyData {Health = {Value = health}};
            var enemy = _prefabFactory.Spawn(_enemyPrefabs[indexEnemy], position, Quaternion.identity, transform);
            enemy.GetComponent<AIDestinationSetter>().target = _target;
            var children = enemy.GetComponentsInChildren<ScorerDistanceToDynamicPosition>();
            foreach (var child in children)
            {
                child.TransformEnemy = _target;
            }

            enemy.GetComponentInChildren<AttackEnemy>().Damage = damage;

            var enemyView = enemy.GetComponent<EnemyView>();
            var enemyPresenter = new EnemyPresenter(enemyView, enemyData);
            enemyView.Initialize(enemyPresenter);
                
            var healthBar = Instantiate(_healthBarPrefab, _canvas.transform).GetComponent<HealthEnemyBarView>();
            healthBar.transform.SetAsFirstSibling();
            var healthBarPresenter = new HealthEnemyBarPresenter(healthBar, enemyData);
            healthBar.Initialize(healthBarPresenter, enemy.GetComponent<Transform>(), _camera, _canvas.GetComponent<RectTransform>());

        }
    }
}