using UnityEngine;

namespace Core.Systems.Movement
{
    public class KeyboardInputSystem : InputControl
    {
        public override Vector2 CurrentInput()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}