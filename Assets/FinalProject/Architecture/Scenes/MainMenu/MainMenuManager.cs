using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        private ExitHelper _exitHelper;

        [Inject]
        private void Construct(ExitHelper exitHelper)
        {
            _exitHelper = exitHelper;
        }
        
        public void OnContinue()
        {
            SceneManager.LoadScene("PlayerCreation");
        }

        public void OnExit()
        {
            _exitHelper.Exit();
        }
    }
}
