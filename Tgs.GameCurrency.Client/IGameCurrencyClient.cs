namespace Tgs.GameCurrency.Client
{
	public interface IGameCurrencyClient
	{
		public ValueTask<decimal> GetExchangeRateFundInAsync(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default);

		public ValueTask<decimal> GetExchangeRateFundOutAsync(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default);
	}
}
