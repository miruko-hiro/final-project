using FinalProject.Architecture.Helpers.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _creatorsPanel;
        private ExitHelper _exitHelper;

        [Inject]
        private void Construct(ExitHelper exitHelper)
        {
            _exitHelper = exitHelper;
        }

        public void OnSettingsClick()
        {
            _settingsPanel.SetActive(true);
        }

        public void OnCreatorsClick()
        {
            _creatorsPanel.SetActive(true);
        }

        public void OnExitClick()
        {
            _exitHelper.Exit();
        }
    }
}
