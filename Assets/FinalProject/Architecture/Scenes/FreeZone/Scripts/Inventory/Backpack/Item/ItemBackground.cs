using UnityEngine;
using UnityEngine.EventSystems;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.Backpack.Item
{
    public class ItemBackground : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            var pointer = eventData.pointerDrag;
            var otherItemTransform = pointer.transform;

            var item = GetComponentInChildren<ItemView>();
            
            if (item != null)
            {
                var ownItemTransform = item.transform;
                ownItemTransform.SetParent(otherItemTransform.parent);
                ownItemTransform.localPosition = Vector3.zero;
            }

            var itemParent = pointer.GetComponentInParent<PlayerItem>();
            if(itemParent != null) 
                pointer.GetComponentInParent<PlayerItem>().SetItem(item);
            
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
        }
    }
}