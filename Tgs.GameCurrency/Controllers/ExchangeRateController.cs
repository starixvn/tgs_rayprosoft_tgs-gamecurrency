using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tgs.GameCurrency.ViewModels;

namespace Tgs.GameCurrency.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController : ControllerBase
{
	private readonly IEnumerable<GameProviderExchangeRate> _gameProviderExchangeRates;

	public ExchangeRateController(
		IOptions<GameCurrencySettingsOption> options)
	{
		_gameProviderExchangeRates = options.Value.GameProviderExchangeRates ?? Enumerable.Empty<GameProviderExchangeRate>();
	}

	[HttpPost("fund-in")]
	public decimal GetExchangeRateFundIn(ExchangeRateFundViewModel model)
	{
		if (model.Amount == 0)
		{
			return model.Amount;
		}

		var exchangeRate = _gameProviderExchangeRates
			.Where(x => x.GameProviderCode.Equals(model.GameProviderCode, StringComparison.InvariantCultureIgnoreCase)
			&& x.CurrencyCode.Equals(model.CurrencyCode, StringComparison.OrdinalIgnoreCase))
			.Select(x => x.ExchangeRate)
			.SingleOrDefault(1);

		return decimal.Round(model.Amount * exchangeRate, 6, MidpointRounding.ToZero);
	}

	[HttpPost("fund-out")]
	public decimal GetExchangeRateFundOut(ExchangeRateFundViewModel model)
	{
		if (model.Amount == 0)
		{
			return model.Amount;
		}

		var exchangeRate = _gameProviderExchangeRates
			.Where(x => x.GameProviderCode.Equals(model.GameProviderCode, StringComparison.InvariantCultureIgnoreCase)
			&& x.CurrencyCode.Equals(model.CurrencyCode, StringComparison.OrdinalIgnoreCase))
			.Select(x => x.ExchangeRate)
			.SingleOrDefault(1);

		return decimal.Round(model.Amount / exchangeRate, 6, MidpointRounding.ToZero);
	}

	[HttpGet]
	public IEnumerable<GameProviderExchangeRate> List()
		=> _gameProviderExchangeRates;
}
