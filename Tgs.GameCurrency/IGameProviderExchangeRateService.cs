namespace Tgs.GameCurrency
{
	public interface IGameProviderExchangeRateService
	{
		decimal ConvertGameProviderFunds(decimal exchangeRate, decimal amount);

		decimal ConvertPlatformBalance(decimal exchangeRate, decimal balance);

		decimal ConvertPlatformRounds(decimal exchangeRate, decimal amount);

		decimal GetExchangeRates(string gameProviderCode, string currencyCode);

		IEnumerable<GameProviderExchangeRate> GetExchangeRates();
	}
}
