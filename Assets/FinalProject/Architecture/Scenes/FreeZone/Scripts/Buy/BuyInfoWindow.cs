using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Buy
{
    public class BuyInfoWindow : MonoBehaviour
    {
        [SerializeField] private InfoWindow _infoWindow;
        [SerializeField] private BuyWindow _buyWindow;
        
        public void OnClickBuy()
        {
            var success = _buyWindow.OnClickBuy(_infoWindow.ItemProperties);
            if (success) gameObject.SetActive(false);
        }
    }
}