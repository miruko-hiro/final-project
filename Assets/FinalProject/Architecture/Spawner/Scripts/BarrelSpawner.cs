using System.Collections.Generic;
using UnityEngine;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class BarrelSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _barrelPrefabs;

        public int NumberOfBarrelPrefabs => _barrelPrefabs.Count;
        
        public void Generation(int indexBarrel, Vector2 position)
        {
            var barrel = Instantiate(_barrelPrefabs[indexBarrel], transform);
            barrel.transform.position = position;
        }
    }
}