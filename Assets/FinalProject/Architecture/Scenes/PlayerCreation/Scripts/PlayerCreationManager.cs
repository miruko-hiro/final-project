using FinalProject.Architecture.Characters.Player;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Player.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Characters.Scripts.Weapon;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Inventory.Backpack.Interactors;
using FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts
{
    public class PlayerCreationManager : MonoBehaviour
    {
        [SerializeField] private GameObject humanoidPrefab;
        private PlayerCreationView _player;
        private AppearanceIssuanceSystem _dispenser;
        private UIManager _uiManager;

        private GenderTypeChanger _genderTypeChanger;
        private HairChanger _hairChanger;
        private BeardChanger _beardChanger;

        private GameManager _gameManager;

        [Inject]
        private void Construct(AppearanceIssuanceSystem dispenser, UIManager uiManager, GameManager gameManager)
        {
            _dispenser = dispenser;
            _uiManager = uiManager;
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _player = Instantiate(humanoidPrefab).GetComponent<PlayerCreationView>();
            _player.transform.position = new Vector2(-4.5f, 0f);
            _player.transform.localScale = new Vector3(20f, 20f, 1f);

            var raceProperties = _gameManager.GetInteractor<PlayerRaceInteractor>().RaceProperties;
            _player.Race = _dispenser.GetHumanoid(raceProperties);

            var bodyProperties = _gameManager.GetInteractor<PlayerBodyInteractor>().ArmorProperties;
            _player.BodyArmor = _dispenser.GetBodyArmor(bodyProperties);

            var weaponProperties = _gameManager.GetInteractor<PlayerWeaponInteractor>().WeaponProperties;
            _player.RightHand = _dispenser.GetWeapon(weaponProperties);
            
            _genderTypeChanger = new GenderTypeChanger(_gameManager, _player, _dispenser);
            _hairChanger = new HairChanger(_gameManager, _player, _dispenser);
            _beardChanger = new BeardChanger(_gameManager, _player, _dispenser);
            
            var staff = new WeaponProperties(ItemType.Weapon, WeaponType.Staff, MagicType.Fire, 0, 1, 5, "item");
            _gameManager.GetInteractor<BackpackWeaponsInteractor>().AddWeapon(staff);
            
            var bow = new WeaponProperties(ItemType.Weapon, WeaponType.Bow, MagicType.None, 0, 1, 5, "item");
            _gameManager.GetInteractor<BackpackWeaponsInteractor>().AddWeapon(bow);

            OnOpen();
        }

        private void OnOpen()
        {
            _uiManager.ChangedGenderType += _genderTypeChanger.Change;
            _uiManager.ChangedHairStyle += _hairChanger.ChangeStyle;
            _uiManager.ChangedHairColor += _hairChanger.ChangeColor;
            _uiManager.ChangedBeardStyle += _beardChanger.ChangeStyle;
            _uiManager.ChangedBeardColor += _beardChanger.ChangeColor;
        }

        private void OnClose()
        {
            _uiManager.ChangedGenderType -= _genderTypeChanger.Change;
            _uiManager.ChangedHairStyle -= _hairChanger.ChangeStyle;
            _uiManager.ChangedHairColor -= _hairChanger.ChangeColor;
            _uiManager.ChangedBeardStyle -= _beardChanger.ChangeStyle;
            _uiManager.ChangedBeardColor -= _beardChanger.ChangeColor;
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}
