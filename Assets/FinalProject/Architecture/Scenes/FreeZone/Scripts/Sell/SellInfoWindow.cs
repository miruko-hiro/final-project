using FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy;
using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Sell
{
    public class SellInfoWindow : MonoBehaviour
    {
        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private SellWindow _sellWindow;
        
        public void OnClickSell()
        {
            var success = _sellWindow.OnClickSell(_infoWindow.ItemProperties);
            if (success) gameObject.SetActive(false);
        }
    }
}