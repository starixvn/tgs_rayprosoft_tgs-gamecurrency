namespace Tgs.GameCurrency.Client;

public record ConvertPlatformBalanceResult(
	decimal ExchangeRate,
	decimal Balance,
	decimal FreeBalance,
	decimal OutstandingBalance);
