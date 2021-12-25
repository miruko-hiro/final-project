using FinalProject.Architecture.Characters.Enemy.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Systems.Attack
{
    public class ArrowAttack : MonoBehaviour
    {
        [SerializeField] private CharacterSound _shootSound;
        private int _damage;
        private float _speed = 0.1f;
        private BoxCollider2D _collider;
        private Transform _transform;
        private bool _isFlight = false;
        private Vector2 _direction;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _transform = GetComponent<Transform>();
        }

        private void OnEnable()
        {
            _collider.enabled = true;
        }

        private void FixedUpdate()
        {
            if(!_isFlight) return;
            
            _transform.Translate(_direction * _speed, Space.World);
        }

        public void Move(Vector2 direction, Vector2 startPosition, int damage)
        {
            _shootSound.SoundEffect();
            _damage = damage;
            var denominator = Mathf.Abs(Mathf.Abs(direction.x) - Mathf.Abs(direction.y)) < 0.01f ? 1.5f : 1f;
            transform.position = startPosition + (direction / denominator);
            var angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            _direction = direction;
            _isFlight = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _isFlight = false;
            _collider.enabled = false;
            if (other.CompareTag("Enemy") || other.CompareTag("Statics"))
            {
                other.gameObject.GetComponentInChildren<IAttackTrigger>().TakeHit(_damage);
            }
            gameObject.SetActive(false);
        }
    }
}