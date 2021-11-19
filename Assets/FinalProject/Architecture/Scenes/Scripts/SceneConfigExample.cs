using System;
using System.Collections.Generic;
using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;

namespace FinalProject.Architecture.Scenes.Scripts
{
    public class SceneConfigExample: SceneConfig
    {
        public const string sceneName = "MainMenu";

        public override string SceneName => sceneName;

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();
            
            CreateInteractor<BankInteractor>(interactorsMap);

            return interactorsMap;
        }

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoriesMap = new Dictionary<Type, Repository>();

            CreateRepository<BankRepository>(repositoriesMap);

            return repositoriesMap;
        }
    }
}