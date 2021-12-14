using System.Collections;
using FinalProject.Architecture.Characters.Player.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Items.Scripts
{
    public class Coin : Item
    {
        private CircleCollider2D _collider;
        private Transform _transform;
        private int _money = 1;

        private void OnEnable()
        {
            _collider.enabled = true;
        }

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            _transform = GetComponent<Transform>();
        }

        public void Initialize(int money)
        {
            _money = money;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                StartCoroutine(GoToPlayerCoroutine(other.transform, other.gameObject.GetComponentInChildren<PlayerView>()));
                _collider.enabled = false;
            }
        }

        private IEnumerator GoToPlayerCoroutine(Transform playerTransform, PlayerView playerView)
        {
            var step =  3f * Time.fixedDeltaTime; 
            
            while (Vector2.Distance(_transform.position, playerTransform.position) > 0.1f)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, playerTransform.position, step);
                yield return new WaitForFixedUpdate();
            }
            
            playerView.AddMoney(_money);
            gameObject.SetActive(false);
        }
    }
}