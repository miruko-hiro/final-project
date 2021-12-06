using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Architecture.UI.Scripts
{
    public abstract class HealthBar : MonoBehaviour
    {
        [SerializeField] protected Image _healthImage;

        public abstract void ReduceHealth(float amount, int newHealth, int maxHealth);
    }
}