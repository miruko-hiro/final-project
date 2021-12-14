using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts.Systems.Movement;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Utils;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Scripts.Systems.Attack
{
    public class BowAttackSystem : MonoBehaviour
    {
        [SerializeField] private InputControl _inputControl;
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] private ArrowAttack _arrowAttackPrefab;
        [SerializeField] private Transform _arrowAttackContainer;
        private PoolMonoZenject<ArrowAttack> _arrowPool;
        private const float _cooldown = 1f;
        private float _time = -1f;
        private GameManager _gameManager;
        private PlayerAttackInteractor _interactor;
        private PrefabFactory _prefabFactory;
        
        [Inject]
        private void Construct(GameManager gameManager, PrefabFactory prefabFactory)
        {
            _gameManager = gameManager;
            _prefabFactory = prefabFactory;
        }
        
        private void Awake()
        {
            _interactor = _gameManager.GetInteractor<PlayerAttackInteractor>();
            _arrowPool = new PoolMonoZenject<ArrowAttack>(_arrowAttackPrefab, _prefabFactory, 3, _arrowAttackContainer);
        }

        private void Update()
        {
            Attack(_inputControl.CurrentInput());
        }
        
        private void Attack(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                return;
            }

            if (_time < 0f)
            {
                _time = _cooldown;
                var arrowAttack = _arrowPool.GetFreeElement();
                arrowAttack.Move(direction, _transformPlayer.position, _interactor.Attack);
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }
    }
}