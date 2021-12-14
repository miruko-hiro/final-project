using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Traps.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class TrapSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _trapPrefabs;

        public int NumberOfTrapPrefabs => _trapPrefabs.Count;
        private PrefabFactory _prefabFactory;

        [Inject]
        private void Construct(PrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
        }
        
        public void Generation(int indexTrap, Vector2 position, int damage)
        {
            var trap = _prefabFactory.Spawn(_trapPrefabs[indexTrap], transform).GetComponent<Trap>();
            trap.Damage = damage;
            trap.transform.position = position;
        }
    }
}