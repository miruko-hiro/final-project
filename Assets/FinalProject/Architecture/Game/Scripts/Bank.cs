using System;
using FinalProject.Architecture.Interactors.Scripts;

namespace FinalProject.Architecture.Game.Scripts
{
    public static class Bank
    {
        public static event Action OnBankInitializeEvent;
        
        private static BankInteractor _bankInteractor;

        public static int Coins
        {
            get
            {
                CheckClass();
                return _bankInteractor.Coins;
            }
        }

        public static bool IsInitialize { get; private set; }

        public static void Initialize(BankInteractor interactor)
        {
            _bankInteractor = interactor;
            IsInitialize = true;
            OnBankInitializeEvent?.Invoke();
        }

        public static bool IsEnoughCoins(int value)
        {
            CheckClass();
            return _bankInteractor.IsEnoughCoins(value);
        }

        public static void AddCoins(int value)
        {
            CheckClass();
            _bankInteractor.AddCoins(value);
        }

        public static void SpendCoins(int value)
        {
            CheckClass();
            _bankInteractor.SpendCoins(value);
        }

        private static void CheckClass()
        {
            if (!IsInitialize)
                throw new Exception("Bank is not initialize yet");
        }
    }
}