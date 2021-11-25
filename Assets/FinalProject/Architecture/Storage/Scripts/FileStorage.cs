using System;
using System.Collections;
using System.IO;
using System.Threading;
using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Storage.Scripts
{
    public class FileStorage: StorageBase
    {
        public string FilePath { get; }
		
        public FileStorage(string fileName)
        {
            var folder = "Saves";
            var folderPath = $"{Application.persistentDataPath}/{folder}";
            if (!Directory.Exists(folderPath)) 
                Directory.CreateDirectory(folderPath);

            FilePath = $"{folderPath}/{fileName}";
            Debug.Log(FilePath);
        }
            
        protected override void SaveInternal()
        {
            var file = File.Create(FilePath);
            Formatter.Serialize(file, GameData);
            file.Close();
        }

        protected override void SaveAsyncInternal(Action callback = null)
        {
            var thread = new Thread(() => SaveDataTaskThreaded(callback));
            thread.Start();
        }
		
        private void SaveDataTaskThreaded(Action callback) {
            Save();
            callback?.Invoke();
        }

        protected override Coroutine SaveStarterInternal(Coroutines coroutines, Action callback = null)
        {
            return coroutines.StartRoutine(SaveCoroutine(callback));
        }
		
        private IEnumerator SaveCoroutine(Action callback) {
            var threadEnded = false;
			
            SaveAsync(() => {
                threadEnded = true;
            });
			
            while (!threadEnded)
                yield return null;
			
            callback?.Invoke();
        }

        protected override void LoadInternal()
        {
            if (!File.Exists(FilePath)) {
                var gameDataByDefault = new GameData();
                GameData = gameDataByDefault;
                Save();
            }

            var file = File.Open(FilePath, FileMode.Open);
            GameData = (GameData) Formatter.Deserialize(file);
            file.Close();
        }

        protected override void LoadAsyncInternal(Action<GameData> callback = null)
        {
            var thread = new Thread(() => LoadDataTaskThreaded(callback));
            thread.Start();
        }
        
        private void LoadDataTaskThreaded(Action<GameData> callback) {
            Load();
            callback?.Invoke(GameData);
        }

        protected override Coroutine LoadStarterInternal(Coroutines coroutines, Action<GameData> callback = null)
        {
            return coroutines.StartRoutine(LoadCoroutine(callback));
        }
        
        private IEnumerator LoadCoroutine(Action<GameData> callback) {
            var threadEnded = false;
            var gameData = new GameData();
			
            LoadAsync((loadedData) => {
                threadEnded = true;
            });
			
            while (!threadEnded)
                yield return null;
			
            callback?.Invoke(gameData);
        }
    }
}