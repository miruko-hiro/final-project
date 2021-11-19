using UnityEngine;

namespace FinalProject.Architecture.Game.Scripts
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Run();
        }

        private void Update()
        {
            if (!Bank.IsInitialize) return;

            if (Input.GetKeyDown(KeyCode.A))
            {
                Bank.AddCoins(5);
                Debug.Log(Bank.Coins);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Bank.SpendCoins(5);
                Debug.Log(Bank.Coins);
            }
        }
    }
}