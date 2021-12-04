using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Architecture.Characters.Enemy.UtilityAI.Action;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy.UtilityAI
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float updateTime = 0.1f;
        private List<BaseAction> _actions;

        private bool _isEnable = true;
        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                if(_isEnable && value) return;
                _isEnable = value;
                if(_isEnable) StartCoroutine(SelectActionAI());
            }
        }

        private void Awake()
        {
            _actions = GetComponentsInChildren<BaseAction>().ToList();
        }

        private void Start()
        {
            StartCoroutine(SelectActionAI());
        }

        private IEnumerator SelectActionAI()
        {
            BaseAction actionInProgress = _actions.OrderBy(p => p.GetScores()).Last();

                
            while (_isEnable)
            {
                yield return new WaitForSeconds(updateTime);
                
                var biggestAction = _actions.OrderBy(p => p.GetScores()).Last();
                if (!biggestAction.Equals(actionInProgress))
                {
                    if ((actionInProgress.IsEnabled && actionInProgress.IsInterrupted || !actionInProgress.IsEnabled) && biggestAction.GetScores() > 0)
                    {
                        actionInProgress.Stop();
                        biggestAction.Play();
                        actionInProgress = biggestAction;
                    }
                }
                else
                {
                    if(!actionInProgress.IsEnabled && actionInProgress.GetScores() > 0)
                    {
                        actionInProgress.Play();
                    }
                }
            }
            
            foreach (var action in _actions)
            {
                action.Stop();
            }
        }
    }
}