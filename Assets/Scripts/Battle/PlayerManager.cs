using Core.Helpers;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        private Player _player;
        private PrefabFactory _prefabFactory;

        [Inject]
        private void Construct(PrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
        }

        private void Start()
        {
            _player = _prefabFactory.Spawn(playerPrefab).GetComponent<Player>();
        }
    }
}
