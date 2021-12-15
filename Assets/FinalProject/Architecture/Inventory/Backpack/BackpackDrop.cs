using FinalProject.Architecture.Inventory.Backpack.Item;
using FinalProject.Architecture.Settings.SoundEffects;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace FinalProject.Architecture.Inventory.Backpack
{
    public class BackpackDrop : MonoBehaviour, IDropHandler
    {
        
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
            var item = pointer.GetComponent<ItemView>();
            
            if(item.GetComponentInParent<BackpackDrop>() != null) return;
            
            pointer.GetComponentInParent<PlayerItem>().SetItem(null);
            _soundEffectsCollection.AddSoundEffect(_audioClip);
            _backpackView.Presenter.Add(item.Presenter.ItemProperties);
            Destroy(pointer.gameObject);
        }
    }
}