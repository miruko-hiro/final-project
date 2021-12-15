using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Inventory.Backpack;
using FinalProject.Architecture.Inventory.Backpack.Item;
using FinalProject.Architecture.Settings.SoundEffects;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

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
        [Space(10)] 
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private BackpackView _backpackView;
        private SoundEffectsCollection _soundEffectsCollection;

        [Inject]
        private void Construct(SoundEffectsCollection soundEffectsCollection)
        {
            _soundEffectsCollection = soundEffectsCollection;
        }
        
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
                _backpackView.Presenter.Add(item.Presenter.ItemProperties);
                Destroy(item.gameObject);
            }
            
            otherItemTransform.SetParent(playerOutfit.transform);
            otherItemTransform.localPosition = Vector3.zero;
            playerOutfit.SetItem(newItem);
            _soundEffectsCollection.AddSoundEffect(_audioClip);
            _backpackView.Presenter.Remove(newItem.Presenter.ItemProperties);
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