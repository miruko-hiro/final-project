namespace FinalProject.Architecture.Barrels.Scripts
{
    public class BarrelPresenter
    {
        private readonly BarrelView _view;
        private readonly BarrelData _model;

        public BarrelPresenter(BarrelView view, BarrelData model)
        {
            _view = view;
            _model = model;

            OnOpen();
        }

        private void OnOpen()
        {
            _view.OnTakeDamageEvent += ChangeHealth;
            _model.ChangeHealth += Die;
        }
        
        private void ChangeHealth(int damage)
        {
            _model.Health -= damage;
        }
        
        private void Die(int health)
        {
            if (health > 0) return;
            OnClose();
            _view.Die();
        }

        private void OnClose()
        {
            _view.OnTakeDamageEvent -= ChangeHealth;
            _model.ChangeHealth -= Die;
        }

        ~BarrelPresenter()
        {
            OnClose();
        }
    }
}