using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Systems.Movement
{
    public abstract class InputControl : MonoBehaviour
    {
        public abstract Vector2 CurrentInput();
    }
}