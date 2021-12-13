using System;
using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Scenes.Scripts.Config;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public class Scene: IScene
    {
        public SceneConfig SceneConfig { get; }
        public ComponentsBase<IInteractor> InteractorsBase { get; }
        public StorageBase Storage { get; private set; }
        
        public Scene(SceneConfig config)
        {
            SceneConfig = config;
            InteractorsBase = new ComponentsBase<IInteractor>(config.InteractorsReferences);
        }
        
        public void SendMessageOnCreate() {
            InteractorsBase.SendMessageOnCreate();
        }

        public void InitializeStarter()
        {
            InitializeCoroutine();
        }
        
        private void InitializeCoroutine() {
            // TODO: Load storage here if needed.
            if (SceneConfig.SaveDataForThisScene) {
                Storage = new FileStorage(SceneConfig.SaveName);
                Storage.Load();
            }

            InteractorsBase.InitializeAllComponents();
            
            InteractorsBase.SendMessageOnInitialize(Storage);
        }

        public void Start()
        {
            InteractorsBase.SendMessageOnStart();
        }

        public void Save()
        {
            Storage?.Save();
        }

        public void SaveAsync(Action callback = null)
        {
            Storage?.SaveAsync(callback);
        }

        public void DeleteSave()
        {
            Storage?.DeleteSave();
        }

        public T GetInteractor<T>() where T : IInteractor {
            return InteractorsBase.GetComponent<T>();
        }
        
        public IEnumerable<T> GetInteractors<T>() where T : IInteractor {
            return InteractorsBase.GetComponents<T>();
        }
    }
}