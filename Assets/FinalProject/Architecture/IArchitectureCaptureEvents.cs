using FinalProject.Architecture.Scenes.Scripts;
using FinalProject.Architecture.Storage.Scripts;

namespace FinalProject.Architecture
{
    public interface IArchitectureCaptureEvents
    {
        public void OnCreate(); // 1 use 1

        public void OnInitialize(StorageBase storage, IScene scene); // 2 use only after 1

        public void OnStart(); // 3 use only after 1 and 2
    }
}