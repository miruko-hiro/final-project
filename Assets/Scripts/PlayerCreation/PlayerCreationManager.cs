using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;
using UnityEngine;
using Zenject;

namespace PlayerCreation
{
    public class PlayerCreationManager : MonoBehaviour
    {
        [SerializeField] private GameObject humanoidPrefab;
        private Humanoid _player;
        private AppearanceIssuanceSystem _appearanceIssuanceSystem;

        [Inject]
        private void Construct(AppearanceIssuanceSystem appearanceIssuanceSystem)
        {
            _appearanceIssuanceSystem = appearanceIssuanceSystem;
        }

        private void Start()
        {
            _player = Instantiate(humanoidPrefab).GetComponent<Humanoid>();
            _player.Race = _appearanceIssuanceSystem.GetHumanoid(0, HumanoidRace.Orc, HumanoidGender.Male);
        }
    }
}
