using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Configs;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public class Scene: IScene
    {
        public SceneConfig SceneConfig { get; }
        public ComponentsBase<IRepository> RepositoriesBase { get; }
        public ComponentsBase<IInteractor> InteractorsBase { get; }
        
        public StorageBase Storage { get; private set; }
        
        public Scene(SceneConfig config) {
            SceneConfig = config;
            RepositoriesBase = new ComponentsBase<IRepository>(config.RepositoriesReferences);
            InteractorsBase = new ComponentsBase<IInteractor>(config.InteractorsReferences);
        }

        public void SendMessageOnCreate() {
            RepositoriesBase.SendMessageOnCreate();
            InteractorsBase.SendMessageOnCreate();
        }

        public Coroutine InitializeStarter()
        {
            return Coroutines.StartRoutine(InitializeCoroutine());
        }
        
        private IEnumerator InitializeCoroutine() {
            // TODO: Load storage here if needed.
            if (SceneConfig.SaveDataForThisScene) {
                Storage = new FileStorage(SceneConfig.SaveName);
                Storage.Load();
            }

            yield return RepositoriesBase.InitializeAllComponentsStarter();
            yield return InteractorsBase.InitializeAllComponentsStarter();
            
            RepositoriesBase.SendMessageOnInitialize();
            InteractorsBase.SendMessageOnInitialize();
        }

        public void Start()
        {
            RepositoriesBase.SendMessageOnStart();
            InteractorsBase.SendMessageOnStart();
        }

        public void Save()
        {
            Storage?.Save();
        }

        public T GetRepository<T>() where T : IRepository {
            return RepositoriesBase.GetComponent<T>();
        }

        public IEnumerable<T> GetRepositories<T>() where T : IRepository {
            return RepositoriesBase.GetComponents<T>();
        }

        public T GetInteractor<T>() where T : IInteractor {
            return InteractorsBase.GetComponent<T>();
        }
        
        public IEnumerable<T> GetInteractors<T>() where T : IInteractor {
            return InteractorsBase.GetComponents<T>();
        }
    }
}