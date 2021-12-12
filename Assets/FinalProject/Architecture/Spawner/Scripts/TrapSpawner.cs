using System.Collections.Generic;
using FinalProject.Architecture.Traps.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Spawner.Scripts
{
    public class TrapSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _trapPrefabs;

        public int NumberOfTrapPrefabs => _trapPrefabs.Count;
        
        public void Generation(int indexTrap, Vector2 position, int damage)
        {
            var barrel = Instantiate(_trapPrefabs[indexTrap], transform).GetComponent<Trap>();
            barrel.Damage = damage;
            barrel.transform.position = position;
        }
    }
}