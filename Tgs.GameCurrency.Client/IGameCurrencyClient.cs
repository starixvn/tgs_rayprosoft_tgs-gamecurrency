namespace Tgs.GameCurrency.Client;

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
        decimal freeBalance,
        decimal outstandingBalance,
        CancellationToken cancellationToken = default);

    public ValueTask<ConvertPlatformRoundsResult> ConvertPlatformRoundsAsync(
        string gameProviderCode,
        string currencyCode,
        decimal bet,
        decimal validBet,
        decimal settle,
        decimal commission,
        decimal turnover,
        decimal winLoss,
        CancellationToken cancellationToken = default);
}
