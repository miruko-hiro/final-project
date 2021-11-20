using FinalProject.Architecture.Interactors.Scripts;
using FinalProject.Architecture.Repositories.Scripts;
using FinalProject.Architecture.Utils.Attributes;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.Configs
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Architecture/Scenes/Configs")]
    public sealed class SceneConfig: ScriptableObject
    {
        [SerializeField, SceneName] private string _sceneName;
        
        [Header("Core Architecture")]
        [SerializeField, ClassReference(typeof(Repository))]
        private string[] _repositoryReferences;
        
        [SerializeField, ClassReference(typeof(Interactor))]
        private string[] _interactorsReferences;
        
        [Header("Storage Settings")]
        [SerializeField] private bool _saveDataForThisScene;
        [SerializeField] private string _saveName;
        
        public string SceneName => _sceneName;
        public string[] RepositoriesReferences => _repositoryReferences;
        public string[] InteractorsReferences => _interactorsReferences;
        public bool SaveDataForThisScene => _saveDataForThisScene;
        public string SaveName => _saveName;
    }
}