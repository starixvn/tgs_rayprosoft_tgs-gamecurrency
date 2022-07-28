namespace Tgs.GameCurrency.Client
{
	public interface IGameCurrencyClient
	{
		public ValueTask<decimal> GetExchangeRateFundOut(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default);
		public ValueTask<decimal> GetExchangeRateFundIn(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default);
	}
}
