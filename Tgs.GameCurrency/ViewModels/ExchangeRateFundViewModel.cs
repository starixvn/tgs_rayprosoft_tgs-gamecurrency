namespace Tgs.GameCurrency.ViewModels
{
	public record ExchangeRateFundViewModel
	{
		public string GameProviderCode { get; init; } = default!;
		public string CurrencyCode { get; init; } = default!;
		public decimal Amount { get; init; } = default!;
	}
}
