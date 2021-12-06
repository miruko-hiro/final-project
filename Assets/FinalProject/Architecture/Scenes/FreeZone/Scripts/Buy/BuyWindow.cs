using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy
{
    public class BuyWindow : MonoBehaviour
    {
        [SerializeField] private InfoWindow _infoWindow;

        public ItemButton[] GetItems()
        {
            return GetComponentsInChildren<ItemButton>();
        }

        public void OnClick()
        {
            _infoWindow.gameObject.SetActive(true);
        }

        public void OnClickExit()
        {
            gameObject.SetActive(false);
        }
    }
}
