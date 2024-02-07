using MyCoins.Models;

namespace MyCoins.Services
{
    public interface ICoinData
    {
        IEnumerable<Coin> Coins { get; }
        void AddCoin(Coin obj);
        void ReplaceCoinData(Coin obj);
    }
}
