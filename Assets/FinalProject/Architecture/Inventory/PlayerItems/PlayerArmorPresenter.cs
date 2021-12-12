using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Armor;
using FinalProject.Architecture.Characters.Scripts.Types;

namespace FinalProject.Architecture.Inventory.PlayerItems
{
    public class PlayerArmorPresenter
    {
        private readonly IPlayerArmor _view;
        private readonly PlayerArmorInteractor _interactor;
        public ArmorProperties ArmorProperties => _interactor.ArmorProperties;

        public PlayerArmorPresenter(IPlayerArmor view, PlayerArmorInteractor interactor)
        {
            _view = view;
            _interactor = interactor;
            
            OnOpen();
        }
        
        private void LoadData()
        {
            SetArmor(_interactor.ArmorProperties);
        }

        private void OnOpen()
        {
            LoadData();
            
            _view.OnAddItemEvent += SetArmor;
        }

        private void OnClose()
        {
            _view.OnAddItemEvent -= SetArmor;
        }

        private void SetArmor(ArmorProperties armorProperties)
        {
            if (armorProperties == null)
                _interactor.ArmorProperties = new ArmorProperties(ItemType.Body, ArmorType.None, -1, 0, 0, "");
            else
                _interactor.ArmorProperties = armorProperties;
        }

        ~PlayerArmorPresenter()
        {
            OnClose();
        }
    }
}