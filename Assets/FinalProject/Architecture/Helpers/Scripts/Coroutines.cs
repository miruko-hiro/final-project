using System.Collections;
using UnityEngine;

namespace FinalProject.Architecture.Helpers.Scripts
{
    public sealed class Coroutines : MonoBehaviour
    {
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