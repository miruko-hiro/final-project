using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Helpers.Scripts
{
    public class PrefabFactory
    {
        private DiContainer _container;

        [Inject]
        public PrefabFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Spawn(GameObject prefab)
        {
            return Spawn(prefab, Vector3.zero, Quaternion.identity, null);
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            return _container.InstantiatePrefab(prefab, position, rotation, parent);
        }

        public GameObject Spawn(GameObject prefab, Transform parent)
        {
            return _container.InstantiatePrefab(prefab, parent);
        }

        public T Spawn<T>(T prefab, Transform parent) where T : MonoBehaviour
        {
            return _container.InstantiatePrefab(prefab, parent).GetComponent<T>();
        }
    }
}