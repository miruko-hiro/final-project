using Joystick_Pack.Scripts.Joysticks;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Systems.Movement
{
    public class TouchInputSystem: InputControl
    {
        [SerializeField] private FloatingJoystick _leftJoystick;
        
        public override Vector2 CurrentInput()
        {
            return new Vector2(_leftJoystick.Horizontal, _leftJoystick.Vertical);
        }
    }
}