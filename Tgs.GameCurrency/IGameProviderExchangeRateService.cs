namespace Tgs.GameCurrency
{
	public interface IGameProviderExchangeRateService
	{
		decimal ConvertGameProviderFunds(decimal exchangeRate, decimal amount);

		decimal ConvertGameProviderRounds(decimal exchangeRate, decimal amount);

		decimal ConvertPlatformBalance(decimal exchangeRate, decimal balance);

		decimal GetExchangeRates(string gameProviderCode, string currencyCode);

		IEnumerable<GameProviderExchangeRate> GetExchangeRates();
	}
}
