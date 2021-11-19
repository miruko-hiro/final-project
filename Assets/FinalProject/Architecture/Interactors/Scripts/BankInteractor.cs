using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Repositories.Scripts;

namespace FinalProject.Architecture.Interactors.Scripts
{
    public class BankInteractor: Interactor
    {
        private BankRepository _bankRepository;

        public int Coins => _bankRepository.Coins;

        public override void OnCreate()
        {
            _bankRepository = GameManager.GetRepository<BankRepository>();
        }

        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool IsEnoughCoins(int value)
        {
            return Coins >= value;
        }

        public void AddCoins(int value)
        {
            _bankRepository.Coins += value;
            _bankRepository.Save();
        }

        public void SpendCoins(int value)
        {
            _bankRepository.Coins -= value;
            _bankRepository.Save();
        }
    }
}