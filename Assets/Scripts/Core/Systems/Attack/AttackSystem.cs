﻿using System;
using Core.Animation;
using Core.Systems.Movement;
using DG.Tweening;
using UnityEngine;

namespace Core.Systems.Attack
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField] private InputControl _inputControl;
        [SerializeField] private Transform _transformOwn;
        [SerializeField] private Transform _attackTransform;
        [SerializeField] private AnimationHumanoid _animationAttack;
        private bool IsPlaying = false;
        
        private void Update()
        {
            Attack(_inputControl.CurrentInput());
        }

        private void Attack(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                _animationAttack.Stop();
                return;
            }

            if (!IsPlaying)
            {
                IsPlaying = true;
                
                Vector2 pos = _transformOwn.position;
                float angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
                _attackTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                var denominator = Math.Abs(Mathf.Abs(direction.x) - Mathf.Abs(direction.y)) < 0.01f ? 2f : 1.5f;

                _attackTransform.position = (pos + direction) / denominator;
                _animationAttack.Play();

                _transformOwn.DOLocalJump(direction / 2f, 0.5f,1,0.5f)
                    .Append(_transformOwn.DOLocalMove(Vector3.zero, 0.5f))
                    .AppendCallback(() =>
                    {
                        _animationAttack.Stop();
                        IsPlaying = false;
                    });

            }

            
        }
    }
}