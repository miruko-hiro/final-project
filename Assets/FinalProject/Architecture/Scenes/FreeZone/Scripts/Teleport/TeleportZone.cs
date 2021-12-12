using UnityEngine;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts.Teleport
{
    public class TeleportZone : MonoBehaviour
    {
        [SerializeField] private Vector3 _posTeleport;
        [SerializeField] private Vector3 _posCamera;
        [SerializeField] private Transform _mainCamera;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.position = _posTeleport;
                _mainCamera.transform.position = _posCamera;
            }
        }
    }
}
