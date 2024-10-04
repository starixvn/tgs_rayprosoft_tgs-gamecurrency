namespace Tgs.GameCurrency.Common;

public record ConvertGameProviderFundsResult(
	decimal ExchangeRate,
	decimal Amount);
