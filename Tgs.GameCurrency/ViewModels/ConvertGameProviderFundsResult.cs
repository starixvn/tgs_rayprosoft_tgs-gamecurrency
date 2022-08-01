namespace Tgs.GameCurrency.ViewModels;

public record ConvertGameProviderFundsResult(
	decimal ExchangeRate,
	decimal Amount);
