using UnityEngine;

namespace Core.Systems.Movement
{
    public abstract class InputControl : MonoBehaviour
    {
        public abstract Vector2 CurrentInput();
    }
}