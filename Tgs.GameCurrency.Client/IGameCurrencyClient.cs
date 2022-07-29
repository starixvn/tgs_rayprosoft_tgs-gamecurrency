namespace Tgs.GameCurrency.Client
{
	public interface IGameCurrencyClient
	{
		public ValueTask<ExchangeRateBalanceResultViewModel> GetExchangeRateBalanceAsync(string gameProviderCode, string currencyCode, decimal balance, CancellationToken cancellationToken = default);

		public ValueTask<ExchangeRateFundResultViewModel> GetExchangeRateFundInAsync(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default);

		public ValueTask<ExchangeRateFundResultViewModel> GetExchangeRateFundOutAsync(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default);
	}
}
