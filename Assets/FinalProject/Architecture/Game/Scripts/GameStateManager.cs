using System;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Game.Scripts
{
    public class GameStateManager: MonoBehaviour
    {
        public static event Action OnApplicationPausedEvent;
        public static event Action OnApplicationUnpausedEvent;
        public static event Action OnApplicationFocusedEvent;
        public static event Action OnApplicationUnfocusedEvent;
        public static event Action OnApplicationQuitEvent;
        
        [SerializeField] private bool _saveOnPause;
        [SerializeField] private bool _saveOnUnfocus = true;
        [SerializeField] private bool _saveOnExit = true;
        [SerializeField] private bool _isLoggingEnabled;

        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void Start() {
            DontDestroyOnLoad(gameObject);
            
            _gameManager.Run();
            
            if (_isLoggingEnabled)
                Debug.Log($"GAME MANAGER: Game launched: {Application.productName}");
        }
        
        private void OnApplicationPause(bool pauseStatus) {
            if (pauseStatus) {
                if (_isLoggingEnabled)
                    Debug.Log("GAME MANAGER: Paused");
                
                if (_saveOnPause)
                    _gameManager.SaveGame();
                
                OnApplicationPausedEvent?.Invoke();
            }
            else {
                if (_isLoggingEnabled)
                    Debug.Log("GAME MANAGER: Game unpaused");
                
                OnApplicationUnpausedEvent?.Invoke();
            }
        }
        
        private void OnApplicationFocus(bool hasFocus) {
            if (!hasFocus) {
                if (_isLoggingEnabled)
                    Debug.Log("GAME MANAGER: Game focused");
                
                if (_saveOnUnfocus)
                    _gameManager.SaveGame();
                
                OnApplicationUnfocusedEvent?.Invoke();
            }
            else {
                if (_isLoggingEnabled)
                    Debug.Log("GAME MANAGER: Game unfocused");
                
                OnApplicationFocusedEvent?.Invoke();
            }
        }
        
        private void OnApplicationQuit() {
            if (_isLoggingEnabled)
                Debug.Log("GAME MANAGER: Game exited");
            
            if (_saveOnExit)
                _gameManager.SaveGame();
            
            OnApplicationQuitEvent?.Invoke();
        }
    }
}