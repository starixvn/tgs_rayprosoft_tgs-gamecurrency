namespace Tgs.GameCurrency;

public class GameCurrencySettingsOption
{
	public IEnumerable<GameProviderExchangeRate> GameProviderExchangeRates { get; set; } = default!;
}
