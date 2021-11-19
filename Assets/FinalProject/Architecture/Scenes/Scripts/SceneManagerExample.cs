namespace FinalProject.Architecture.Scenes.Scripts
{
    public sealed class SceneManagerExample: SceneManagerBase
    {
        public override void InitSceneMap()
        {
            _sceneConfigMap[SceneConfigExample.sceneName] = new SceneConfigExample();
        }
    }
}