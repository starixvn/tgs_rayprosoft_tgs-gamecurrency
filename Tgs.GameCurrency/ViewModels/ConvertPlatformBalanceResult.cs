namespace Tgs.GameCurrency.ViewModels;

public record ConvertPlatformBalanceResult(
	decimal ExchangeRate,
	decimal Balance);
