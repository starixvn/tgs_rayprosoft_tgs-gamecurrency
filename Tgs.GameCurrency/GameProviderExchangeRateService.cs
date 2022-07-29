using Microsoft.Extensions.Options;

namespace Tgs.GameCurrency
{
	internal class GameProviderExchangeRateService : IGameProviderExchangeRateService
	{
		private readonly IEnumerable<GameProviderExchangeRate> _gameProviderExchangeRates;

		public GameProviderExchangeRateService(IOptions<GameCurrencySettingsOption> options)
		{
			_gameProviderExchangeRates = options.Value.GameProviderExchangeRates ?? Enumerable.Empty<GameProviderExchangeRate>();
		}

		public decimal GetExchangeRates(string gameProviderCode, string currencyCode)
			=> _gameProviderExchangeRates
				.Where(x => x.GameProviderCode.Equals(gameProviderCode, StringComparison.InvariantCultureIgnoreCase)
					&& x.CurrencyCode.Equals(currencyCode, StringComparison.OrdinalIgnoreCase))
				.Select(x => x.ExchangeRate)
				.SingleOrDefault(1);

		public IEnumerable<GameProviderExchangeRate> GetExchangeRates()
			=> _gameProviderExchangeRates;
	}
}
