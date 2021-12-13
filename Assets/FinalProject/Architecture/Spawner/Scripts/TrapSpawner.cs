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
            var trap = Instantiate(_trapPrefabs[indexTrap], transform).GetComponent<Trap>();
            trap.Damage = damage;
            trap.transform.position = position;
        }
    }
}