using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FinalProject.Architecture.Storage.Scripts
{
    [Serializable]
    public class GameData: ISerializationCallbackReceiver
    {
        [SerializeField] private List<string> _keys;
        [SerializeField] private List<object> _values;
        
        private Dictionary<string, object> _dataMap = new Dictionary<string, object>();

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var item in _dataMap)
            {
                _keys.Add(item.Key);
                _values.Add(item.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            _dataMap = new Dictionary<string, object>();

            for (int i = 0; i != Mathf.Min(_keys.Count, _values.Count); i++)
                _dataMap.Add(_keys[i], _values[i]);
        }

        public T Get<T>(string key)
        {
            var founded = _dataMap.TryGetValue(key, out var value);
            if (founded)
                return (T) value;
            
            return default;
        }

        public T Get<T>(string key, T valueByDefault)
        {
            var founded = _dataMap.TryGetValue(key, out var value);
            if (founded)
                return (T) value;

            Set(key, valueByDefault);
            return valueByDefault;
        }

        public void Set<T>(string key, T newValue)
        {
            _dataMap[key] = newValue;
        }

        public void Remove<T>(T value)
        {
            var obj = (object) value;
            var key = _dataMap.First(kvp => kvp.Value == obj).Key;
            _dataMap.Remove(key);
        }

        public override string ToString()
        {
            var line = "";
            foreach (var pair in _dataMap)
                line += $"Pair: {pair.Key} - {pair.Value}\n";
            return line;
        }
    }
}