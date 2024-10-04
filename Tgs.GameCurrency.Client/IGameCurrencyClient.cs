namespace Tgs.GameCurrency.Client;

public interface IGameCurrencyClient
{
	public ValueTask<Common.ConvertGameProviderFundsResult> ConvertGameProviderFundsAsync(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default);

	public ValueTask<Common.ConvertPlatformBalanceResult> ConvertPlatformBalanceAsync(string gameProviderCode, string currencyCode, decimal balance, decimal freeBalance, decimal outstandingBalance, CancellationToken cancellationToken = default);

	public ValueTask<Common.ConvertPlatformRoundsResult> ConvertPlatformRoundsAsync(string gameProviderCode, string currencyCode, decimal bet, decimal validBet, decimal settle, decimal winLoss, decimal turnover, decimal commission, decimal contribute, decimal jackpot, CancellationToken cancellationToken = default);

	public ValueTask<decimal> GetExchangeRate(string gameProviderCode, string currencyCode, CancellationToken cancellationToken = default);
}
