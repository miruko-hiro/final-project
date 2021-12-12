using UnityEngine;

namespace FinalProject.Architecture.Traps.Scripts
{
    public abstract class Trap : MonoBehaviour
    {
        [SerializeField] protected int _damage = 5;
        
        public abstract int Damage { get; set; }
    }
}
