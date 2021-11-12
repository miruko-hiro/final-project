using Core.Player;
using Template.Creatures;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject humanoidPrefab;
        private Humanoid _body;
        private PlayerData _pData;

        [Inject]
        private void Construct(PlayerData playerData)
        {
            _pData = playerData;
        }

        private void Start()
        {
            _body = Instantiate(humanoidPrefab, transform).GetComponent<Humanoid>();
            _body = new CharacterDataInstaller().LoadData(_body, _pData);
        }
    }
}