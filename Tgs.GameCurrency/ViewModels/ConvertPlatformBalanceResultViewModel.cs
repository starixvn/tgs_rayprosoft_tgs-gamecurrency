namespace Tgs.GameCurrency.ViewModels;

public record ConvertPlatformBalanceResultViewModel(
	decimal ExchangeRate,
	decimal Balance);
