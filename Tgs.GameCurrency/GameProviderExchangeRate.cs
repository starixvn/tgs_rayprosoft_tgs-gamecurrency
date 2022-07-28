namespace Tgs.GameCurrency;

public class GameProviderExchangeRate
{
	public string GameProviderCode { get; set; } = default!;
	public string CurrencyCode { get; set; } = default!;
	public string GameProviderCurrencyCode { get; set; } = default!;
	public decimal ExchangeRate { get; set; }
}
