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
    public class PlayerCreationManager : MonoBehaviour, IManager
    {
        [SerializeField] private GameObject humanoidPrefab;
        private Humanoid _player;
        private AppearanceIssuanceSystem _dispenser;
        private UIManager _uiManager;
        private PlayerData _pData;

        private IChanger _genderTypeChanger;
        private IChanger _hairStyleChanger;
        private IChanger _hairColorChanger;
        private IChanger _beardStyleChanger;
        private IChanger _beardColorChanger;

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
            
            _pData.IndexHumanoidRace = 0;
            _pData.HumanoidRace = HumanoidRace.Orc;
            
            _player.Race = _dispenser.GetHumanoid(_pData.IndexHumanoidRace, _pData.HumanoidRace, _pData.HumanoidGender);
            _player.BodyArmor = _dispenser.GetBodyArmor(_pData.IndexBodyArmor, _pData.BodyArmorType);
            
            _genderTypeChanger = new GenderTypeChanger(_pData, _player, _dispenser);
            _hairStyleChanger = new HairStyleChanger(_pData, _player, _dispenser);
            _hairColorChanger = new HairColorChanger(_pData, _player, _dispenser);
            _beardStyleChanger = new BeardStyleChanger(_pData, _player, _dispenser);
            _beardColorChanger = new BeardColorChanger(_pData, _player, _dispenser);

            OnOpen();
        }

        public void OnOpen()
        {
            _uiManager.ChangedGenderType += _genderTypeChanger.Change;
            _uiManager.ChangedHairStyle += _hairStyleChanger.Change;
            _uiManager.ChangedHairColor += _hairColorChanger.Change;
            _uiManager.ChangedBeardStyle += _beardStyleChanger.Change;
            _uiManager.ChangedBeardColor += _beardColorChanger.Change;
        }

        public void OnClose()
        {
            _uiManager.ChangedGenderType -= _genderTypeChanger.Change;
            _uiManager.ChangedHairStyle -= _hairStyleChanger.Change;
            _uiManager.ChangedHairColor -= _hairColorChanger.Change;
            _uiManager.ChangedBeardStyle -= _beardStyleChanger.Change;
            _uiManager.ChangedBeardColor -= _beardColorChanger.Change;
        }

        private void OnDestroy()
        {
            OnClose();
        }
    }
}
