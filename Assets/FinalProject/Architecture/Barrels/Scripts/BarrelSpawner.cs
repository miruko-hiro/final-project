using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FinalProject.Architecture.Barrels.Scripts
{
    public class BarrelSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _barrelPrefabs;
        [SerializeField] private List<Vector3> _positions;

        private void Awake()
        {
            foreach (var position in _positions)
            {
                var barrel = Instantiate(_barrelPrefabs[Random.Range(0, _barrelPrefabs.Count - 1)], transform);
                barrel.transform.position = position;
            }
        }
    }
}