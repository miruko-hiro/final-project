using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Inventory.PlayerItems
{
    public class PlayerRightHandPresenter
    {
        private readonly PlayerRightHand _view;
        private readonly PlayerWeaponInteractor _interactor;

        public WeaponProperties WeaponProperties => _interactor.WeaponProperties;

        public PlayerRightHandPresenter(PlayerRightHand view, GameManager gameManager)
        {
            _view = view;
            _interactor = gameManager.GetInteractor<PlayerWeaponInteractor>();
            
            OnOpen();
        }
        
        private void LoadData()
        {
            SetRightHand(_interactor.WeaponProperties);
        }

        private void OnOpen()
        {
            LoadData();
            
            _view.OnAddItemToRightHandEvent += SetRightHand;
        }

        private void OnClose()
        {
            _view.OnAddItemToRightHandEvent -= SetRightHand;
        }

        private void SetRightHand(WeaponProperties weaponProperties)
        {
            if (weaponProperties == null)
                _interactor.WeaponProperties = new WeaponProperties(ItemType.Weapon, WeaponType.None, MagicType.None, -1, 0, 0, "");
            else
                _interactor.WeaponProperties = weaponProperties;
        }

        ~PlayerRightHandPresenter()
        {
            OnClose();
        }
    }
}