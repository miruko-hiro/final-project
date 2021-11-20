using UnityEngine;

namespace FinalProject.Architecture.Helpers.Scripts
{
    public class GameStateHelper
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Play()
        {
            Time.timeScale = 1;
        }
    }
}