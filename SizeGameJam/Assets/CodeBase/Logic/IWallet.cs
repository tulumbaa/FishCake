namespace CodeBase.Logic
{
    public interface IWallet
    {
        int GetCoins();
        void AddCoins(int addtiveCoins);
        void SubstractCoins(int removeCoins);
    }
}