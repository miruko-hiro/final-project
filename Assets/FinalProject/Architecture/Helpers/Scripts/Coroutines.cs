using System.Collections;
using UnityEngine;

namespace FinalProject.Architecture.Helpers.Scripts
{
    public sealed class Coroutines : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public Coroutine StartRoutine(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void StopRoutine(Coroutine routine)
        {
            StopCoroutine(routine);
        }
    }
}