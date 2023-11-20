using Assets.CodeBase.Logic;

namespace CodeBase.Logic
{
    public class Wallet : IWallet
    {
        private int _coins;

        public int GetCoins() =>
            _coins;

        public void AddCoins(int addtiveCoins) => 
            _coins += addtiveCoins;

        public void SubstractCoins(int removeCoins) => 
            _coins -= removeCoins;
    }
}