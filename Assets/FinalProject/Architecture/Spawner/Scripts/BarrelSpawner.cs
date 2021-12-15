using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class BarrelSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _barrelPrefabs;

        public int NumberOfBarrelPrefabs => _barrelPrefabs.Count;
        private PrefabFactory _prefabFactory;
        private List<GameObject> _barrels = new List<GameObject>();

        [Inject]
        private void Construct(PrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
        }
        
        public void Generation(int indexBarrel, Vector2 position)
        {
            var barrel = _prefabFactory.Spawn(_barrelPrefabs[indexBarrel], transform);
            barrel.transform.position = position;
            _barrels.Add(barrel);
        }

        public void DestroyBarrels()
        {
            foreach (var barrel in _barrels)
            {
                Destroy(barrel);
            }
            _barrels.Clear();
        }
    }
}