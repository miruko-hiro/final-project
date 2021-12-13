using UnityEngine;

namespace FinalProject.Architecture.Scenes.MainMenu.Scripts
{
    public class CreatorsPanel : MonoBehaviour
    {
        private string _developerURL = "https://play.google.com/store/apps/developer?id=MRKHR";

        public void OnGooglePlayClick()
        {
            Application.OpenURL(_developerURL);
        }
        
        public void OnBackClick()
        {
            gameObject.SetActive(false);
        }
    }
}