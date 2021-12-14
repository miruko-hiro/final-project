using System;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Utils
{
    public class PoolMonoZenject<T> where T: MonoBehaviour
    {
        public T Prefab { get; }
        public bool AutoExpand { get; set; } = true;
        public Transform Container { get; }

        private List<T> _pool;
        private PrefabFactory _prefabFactory;

        public PoolMonoZenject(T prefab, PrefabFactory prefabFactory, int count, Transform container = null)
        {
            Prefab = prefab;
            Container = container;
            _prefabFactory = prefabFactory;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = _prefabFactory.Spawn(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (AutoExpand)
                return CreateObject(true);

            throw new Exception($"There is no free elements in pool of type {typeof(T)}");
        }
    }
}