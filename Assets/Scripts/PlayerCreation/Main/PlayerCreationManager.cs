using Core.Interfaces;
using Core.Player;
using PlayerCreation.UI;
using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;
using UnityEngine;
using Zenject;

namespace PlayerCreation.Main
{
    public class PlayerCreationManager : MonoBehaviour
    {
        [SerializeField] private GameObject humanoidPrefab;
        private Humanoid _player;
        private AppearanceIssuanceSystem _dispenser;
        private UIManager _uiManager;
        private PlayerData _pData;

        private GenderTypeChanger _genderTypeChanger;
        private HairChanger _hairChanger;
        private BeardChanger _beardChanger;

        [Inject]
        private void Construct(AppearanceIssuanceSystem dispenser, UIManager uiManager, PlayerData playerData)
        {
            _dispenser = dispenser;
            _uiManager = uiManager;
            _pData = playerData;
        }

        private void Start()
        {
            _player = Instantiate(humanoidPrefab).GetComponent<Humanoid>();
            _player.transform.position = new Vector2(-4.5f, 0f);
            _player.transform.localScale = new Vector3(20f, 20f, 1f);
            
            _pData.HumanoidRace = HumanoidRace.Orc;
            _pData.HumanoidGender = HumanoidGender.Male;
            _pData.HumanoidRaceSprite.Value = _dispenser.GetHumanoid(0, _pData.HumanoidRace, _pData.HumanoidGender);
            _player.Race = _pData.HumanoidRaceSprite.Value;

            _pData.BodyArmorSprite.Value = _dispenser.GetBodyArmor(0, ArmorType.Light);
            _player.BodyArmor = _pData.BodyArmorSprite.Value;

            _pData.RightHandSprite.Value = _dispenser.GetWeapon(0, WeaponType.Sword);
            _player.RightHand = _pData.RightHandSprite.Value;
            
            _genderTypeChanger = new GenderTypeChanger(_pData, _player, _dispenser);
            _hairChanger = new HairChanger(_pData, _player, _dispenser);
            _beardChanger = new BeardChanger(_pData, _player, _dispenser);

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
