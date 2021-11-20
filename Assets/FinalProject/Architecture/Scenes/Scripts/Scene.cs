using System.Collections;
using System.Collections.Generic;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Scenes.Configs;
using FinalProject.Architecture.Storage.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public class Scene: IScene
    {
        public SceneConfig SceneConfig { get; }
        public ComponentsBase<IRepository> RepositoriesBase { get; }
        public ComponentsBase<IInteractor> InteractorsBase { get; }
        public StorageBase Storage { get; private set; }

        private Coroutines _coroutines;
        private InjectionClassFactory _injectionClassFactory;
        
        [Inject]
        public Scene(Coroutines coroutines, InjectionClassFactory injectionClassFactory, SceneConfig config)
        {
            _coroutines = coroutines;
            _injectionClassFactory = injectionClassFactory;
            SceneConfig = config;
            RepositoriesBase = injectionClassFactory.CreateWithParameters<ComponentsBase<IRepository>>(new object[] {config.RepositoriesReferences});
            InteractorsBase = injectionClassFactory.CreateWithParameters<ComponentsBase<IInteractor>>(new object[] {config.InteractorsReferences});
        }
        
        public void SendMessageOnCreate() {
            RepositoriesBase.SendMessageOnCreate();
            InteractorsBase.SendMessageOnCreate();
        }

        public Coroutine InitializeStarter()
        {
            return _coroutines.StartRoutine(InitializeCoroutine());
        }
        
        private IEnumerator InitializeCoroutine() {
            // TODO: Load storage here if needed.
            if (SceneConfig.SaveDataForThisScene) {
                Storage = _injectionClassFactory.CreateWithParameters<FileStorage>(new object[] {SceneConfig.SaveName});
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