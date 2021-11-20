using DG.Tweening;
using FinalProject.Architecture.UI.Scripts;

namespace FinalProject.Architecture.Characters.Enemy.Health
{
    public class HealthEnemyBarView : HealthBar
    {
        private float _duration = 0.5f;
        
        public override void ReduceHealth(float amount)
        {
            _healthImage.DOFillAmount(amount, _duration);
        }
    }
}