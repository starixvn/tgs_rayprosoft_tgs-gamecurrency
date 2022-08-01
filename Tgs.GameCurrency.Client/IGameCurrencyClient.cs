namespace Tgs.GameCurrency.Client
{
	public interface IGameCurrencyClient
	{
		public ValueTask<ConvertGameProviderFundsResult> ConvertGameProviderFunds(
			string gameProviderCode,
			string currencyCode,
			decimal amount,
			CancellationToken cancellationToken = default);

		public ValueTask<ConvertGameProviderRoundsResult> ConvertGameProviderRounds(
			string gameProviderCode,
			string currencyCode,
			ConvertGameProviderRoundsRequest request,
			CancellationToken cancellationToken = default);

		public ValueTask<ConvertPlatformBalanceResult> ConvertPlatformBalance(
							string gameProviderCode,
			string currencyCode,
			decimal balance,
			CancellationToken cancellationToken = default);
	}
}
