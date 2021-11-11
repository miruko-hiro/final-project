using Core.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace MainMenu
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
