using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Inventory.Backpack.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FinalProject.Architecture.Inventory
{
    public class PlayerOutfit : MonoBehaviour, IDropHandler
    {
        [SerializeField] private PlayerItem _playerRightHand;
        [SerializeField] private PlayerItem _playerLeftHand;
        [SerializeField] private PlayerItem _playerHead;
        [SerializeField] private PlayerItem _playerBody;
        [SerializeField] private PlayerItem _playerPants;
        [SerializeField] private PlayerItem _playerBoots;
        
        public void OnDrop(PointerEventData eventData)
        {
            var pointer = eventData.pointerDrag;
            var newItem = pointer.GetComponent<ItemView>();
            var playerOutfit = GetPlayerItem(newItem.ItemType);
            
            if(playerOutfit == null) return;
            
            var otherItemTransform = pointer.transform;
            var item = playerOutfit.GetComponentInChildren<ItemView>();
            
            if (item != null)
            {
                var ownItemTransform = item.transform;
                ownItemTransform.SetParent(otherItemTransform.parent);
                ownItemTransform.localPosition = Vector3.zero;
            }
            
            otherItemTransform.SetParent(playerOutfit.transform);
            otherItemTransform.localPosition = Vector3.zero;
            playerOutfit.SetItem(newItem);
        }

        private PlayerItem GetPlayerItem(ItemType type)
        {
            return type switch
            {
                ItemType.Weapon => _playerRightHand,
                ItemType.Shield => _playerLeftHand,
                ItemType.Head => _playerHead,
                ItemType.Body => _playerBody,
                ItemType.Pants => _playerPants,
                ItemType.Boots => _playerBoots,
                _ => null
            };
        }
    }
}