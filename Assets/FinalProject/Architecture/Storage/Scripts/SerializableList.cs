using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FinalProject.Architecture.Storage.Scripts
{
    [Serializable]
    public class SerializableList
    {
        [SerializeField] private List<object> _elements;

        public void Add<T>(T element)
        {
            _elements ??= new List<object>();
            _elements.Add(element);
        }

        public void Remove<T>(T element)
        {
            _elements ??= new List<object>();
            _elements.Remove(element);
        }

        public List<T> GetList<T>()
        {
            return _elements == null ? new List<T>() : _elements.OfType<T>().ToList();
        }
    }
}