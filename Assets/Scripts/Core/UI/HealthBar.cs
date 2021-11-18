using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public abstract class HealthBar : MonoBehaviour
    {
        [SerializeField] protected Image _healthImage;

        public abstract void ReduceHealth(float amount);
    }
}