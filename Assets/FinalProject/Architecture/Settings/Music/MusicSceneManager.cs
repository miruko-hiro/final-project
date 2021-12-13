using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Settings.Music
{
    public class MusicSceneManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _music;
        private GameManager _gameManager;
        private MusicCollection _musicCollection;
        private MusicManager _musicManager;
        
        [Inject]
        private void Construct(GameManager gameManager, MusicCollection musicCollection, MusicManager musicManager)
        {
            _gameManager = gameManager;
            _musicCollection = musicCollection;
            _musicManager = musicManager;
        }

        private void Awake()
        {
            _musicCollection.Initialize(_musicManager, _gameManager);
        }

        private void Start()
        {
            _musicCollection.AddMusic(_music);
        }
    }
}