using Assets.CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Wallet : MonoBehaviour, IWallet
    {
        private int _coins;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public int GetCoins() =>
            _coins;

        public void AddCoins(int addtiveCoins)
        {
            _coins += addtiveCoins;

            Debug.Log(_coins);
        }

        public void SubstractCoins(int removeCoins) => 
            _coins -= removeCoins;
    }
}