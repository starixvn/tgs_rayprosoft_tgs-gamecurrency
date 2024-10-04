namespace Tgs.GameCurrency.Common;
public record ConvertPlatformBalanceResult(
	decimal ExchangeRate,
	decimal Balance,
	decimal FreeBalance,
	decimal OutstandingBalance);
