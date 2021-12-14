using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Traps.Scripts
{
    public abstract class Trap : MonoBehaviour
    {
        [SerializeField] protected int _damage = 5;
        [SerializeField] protected CharacterSound _sound;
        
        public abstract int Damage { get; set; }
    }
}
