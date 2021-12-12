using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Storage.Scripts.Surrogates;
using UnityEngine;

namespace FinalProject.Architecture.Storage.Scripts
{
    public abstract class StorageBase
    {
        public event Action OnStorageSaveStartedEvent;
        public event Action OnStorageSaveCompletedEvent;
        public event Action<GameData> OnStorageLoadedEvent;

        public static BinaryFormatter Formatter {
            get {
                if (_formatter == null)
                    _formatter = CreateBinaryFormatter();
                return _formatter;
            }
        }
        
        private static BinaryFormatter _formatter;
        public GameData GameData { get; protected set; }

        private static BinaryFormatter CreateBinaryFormatter() {
            var createdFormatter = new BinaryFormatter();
            var selector = new SurrogateSelector();
			
            var vector3Surrogate = new Vector3SerializationSurrogate();
            var vector2Surrogate = new Vector2SerializationSurrogate();
            var quaternionSurrogate = new QuaternionSerializationSurrogate();
			
            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
            selector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2Surrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quaternionSurrogate);
			
            createdFormatter.SurrogateSelector = selector;

            return createdFormatter;
        }
        
        public void Save()
        {
            OnStorageSaveStartedEvent?.Invoke();
            SaveInternal();
            OnStorageSaveCompletedEvent?.Invoke();
        }

        protected abstract void SaveInternal();

        public void SaveAsync(Action callback = null)
        {
            OnStorageSaveStartedEvent?.Invoke();
            SaveAsyncInternal(callback);
            OnStorageSaveCompletedEvent?.Invoke();
        }
        
        protected abstract void SaveAsyncInternal(Action callback = null);

        public Coroutine SaveStarter(Coroutines coroutines, Action callback = null)
        {
            OnStorageSaveStartedEvent?.Invoke();
            return SaveStarterInternal(coroutines,
                () => {
                callback?.Invoke();
                OnStorageSaveCompletedEvent?.Invoke();
            });
        }
        
        protected abstract Coroutine SaveStarterInternal(Coroutines coroutines, Action callback = null);

        public void DeleteSave()
        {
            DeleteSaveInternal();
        }

        protected abstract void DeleteSaveInternal();

        public void Load()
        {
            LoadInternal();
            OnStorageLoadedEvent?.Invoke(GameData);
        }
        
        protected abstract void LoadInternal();
        
        public void LoadAsync(Action<GameData> callback = null) {
            LoadAsyncInternal(loadedData => {
                callback?.Invoke(GameData);
                OnStorageLoadedEvent?.Invoke(GameData);
            });
        }
        
        protected abstract void LoadAsyncInternal(Action<GameData> callback = null);
        
        public Coroutine LoadStarter(Coroutines coroutines, Action<GameData> callback = null) {
            return LoadStarterInternal(coroutines,
                loadedData => {
                callback?.Invoke(GameData);
                OnStorageLoadedEvent?.Invoke(GameData);
            });
        }

        protected abstract Coroutine LoadStarterInternal(Coroutines coroutines, Action<GameData> callback = null);
        
        public T Get<T>(string key) {
            return GameData.Get<T>(key);
        }
		
        public T Get<T>(string key, T valueByDefault) {
            return GameData.Get(key, valueByDefault);
        }

        public void Set<T>(string key, T value) {
            this.GameData.Set(key, value);
        }

        public override string ToString() {
            return this.GameData.ToString();
        }
    }
}