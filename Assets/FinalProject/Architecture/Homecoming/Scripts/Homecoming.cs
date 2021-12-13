using UnityEngine;

namespace FinalProject.Architecture.Homecoming.Scripts
{
    public class Homecoming : MonoBehaviour
    {
        [SerializeField] private GameObject _homecomingPanel;

        public void OnClick()
        {
            _homecomingPanel.SetActive(true);
        }
    }
}
