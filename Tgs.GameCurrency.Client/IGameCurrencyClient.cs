namespace Tgs.GameCurrency.Client
{
    public interface IGameCurrencyClient
    {
        public ValueTask<ConvertGameProviderFundsResult> ConvertGameProviderFundsAsync(
            string gameProviderCode,
            string currencyCode,
            decimal amount,
            CancellationToken cancellationToken = default);

        public ValueTask<ConvertPlatformBalanceResult> ConvertPlatformBalanceAsync(
                            string gameProviderCode,
            string currencyCode,
            decimal balance,
            CancellationToken cancellationToken = default);

        public ValueTask<ConvertPlatformRoundsResult> ConvertPlatformRoundsAsync(
                    string gameProviderCode,
            string currencyCode,
            ConvertPlatformRoundsRequest request,
            CancellationToken cancellationToken = default);
    }
}
