namespace Tgs.GameCurrency
{
	public interface IGameProviderExchangeRateService
	{
		decimal GetExchangeRates(string gameProviderCode, string currencyCode);

		IEnumerable<GameProviderExchangeRate> GetExchangeRates();
	}
}
