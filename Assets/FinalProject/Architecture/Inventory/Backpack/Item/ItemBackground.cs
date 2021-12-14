using FinalProject.Architecture.Settings.SoundEffects;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace FinalProject.Architecture.Inventory.Backpack.Item
{
    public class ItemBackground : MonoBehaviour, IDropHandler
    {
        [SerializeField] private AudioClip _audioClip;
        private SoundEffectsCollection _soundEffectsCollection;
        
        [Inject]
        private void Construct(SoundEffectsCollection soundEffectsCollection)
        {
            _soundEffectsCollection = soundEffectsCollection;
        }
        
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
            _soundEffectsCollection.AddSoundEffect(_audioClip);
        }
    }
}