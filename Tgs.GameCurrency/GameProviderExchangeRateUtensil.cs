using Microsoft.Extensions.Options;

namespace Tgs.GameCurrency;

internal class GameProviderExchangeRateUtensil(IOptions<GameCurrencySettingsOption> options) : IGameProviderExchangeRateUtensil
{
    private readonly IEnumerable<GameProviderExchangeRate> _gameProviderExchangeRates = options.Value.GameProviderExchangeRates ?? Enumerable.Empty<GameProviderExchangeRate>();

    public decimal ConvertGameProviderFunds(decimal exchangeRate, decimal amount)
        => amount == 0 ? amount : decimal.Round(amount / exchangeRate, 6, MidpointRounding.ToZero);

    public decimal ConvertPlatformBalance(decimal exchangeRate, decimal balance)
        => balance == 0 ? balance : decimal.Round(balance * exchangeRate, 6, MidpointRounding.ToZero);

    public decimal ConvertPlatformRounds(decimal exchangeRate, decimal amount)
        => amount == 0 ? amount : decimal.Round(amount * exchangeRate, 6, MidpointRounding.ToZero);

    public decimal GetExchangeRates(string gameProviderCode, string currencyCode)
        => _gameProviderExchangeRates
            .Where(x => x.GameProviderCode.Equals(gameProviderCode, StringComparison.InvariantCultureIgnoreCase)
                && x.CurrencyCode.Equals(currencyCode, StringComparison.OrdinalIgnoreCase))
            .Select(x => x.ExchangeRate)
            .SingleOrDefault(1);

    public IEnumerable<GameProviderExchangeRate> GetExchangeRates()
        => _gameProviderExchangeRates;
}
