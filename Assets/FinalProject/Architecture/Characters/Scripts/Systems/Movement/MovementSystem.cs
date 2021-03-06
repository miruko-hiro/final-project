using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Systems.Movement
{
    public class MovementSystem : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private InputControl _inputControl;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private AnimationBase _animation;

        private void Update()
        {
            Move(_inputControl.CurrentInput());
        }

        private void Move(Vector2 vector2)
        {
            _rigidbody2D.velocity = vector2 * _speed;

            if (vector2 == Vector2.zero)
            {
                _animation.Stop();
                return;
            }
            _animation.Play();
        }
    }
}