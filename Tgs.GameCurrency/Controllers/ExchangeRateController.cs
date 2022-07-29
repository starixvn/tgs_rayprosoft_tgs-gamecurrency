using Microsoft.AspNetCore.Mvc;
using Tgs.GameCurrency.ViewModels;

namespace Tgs.GameCurrency.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController : ControllerBase
{
	private readonly IGameProviderExchangeRateService _gameProviderExchangeRateService;

	public ExchangeRateController(IGameProviderExchangeRateService gameProviderExchangeRateService)
	{
		_gameProviderExchangeRateService = gameProviderExchangeRateService ?? throw new ArgumentNullException(nameof(gameProviderExchangeRateService));
	}

	/// <summary>
	/// Gets the balance.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="balance">The balance.</param>
	/// <returns></returns>
	[HttpGet("balance")]
	public ExchangeRateBalanceResultViewModel GetBalance(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromQuery] decimal balance)
	{
		var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return balance == 0 ?
			new ExchangeRateBalanceResultViewModel(
				ExchangeRate: exchangeRate,
				Balance: balance) :
			new ExchangeRateBalanceResultViewModel(
				ExchangeRate: exchangeRate,
				Balance: decimal.Round(balance * exchangeRate, 6, MidpointRounding.ToZero));
	}

	/// <summary>
	/// Gets the exchange rate fund in.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="amount">The amount.</param>
	/// <returns></returns>
	[HttpGet("fund/in")]
	public ExchangeRateFundResultViewModel GetExchangeRateFundIn(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromQuery] decimal amount)
	{
		var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return amount == 0 ?
			new ExchangeRateFundResultViewModel(
				ExchangeRate: exchangeRate,
				Amount: amount) :
			new ExchangeRateFundResultViewModel(
				ExchangeRate: exchangeRate,
				Amount: decimal.Round(amount * exchangeRate, 6, MidpointRounding.ToZero));
	}

	/// <summary>
	/// Gets the exchange rate fund out.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="amount">The amount.</param>
	/// <returns></returns>
	[HttpGet("fund/out")]
	public ExchangeRateFundResultViewModel GetExchangeRateFundOut(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromQuery] decimal amount)
	{
		var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return amount == 0 ?
			new ExchangeRateFundResultViewModel(
				ExchangeRate: exchangeRate,
				Amount: amount) :
			new ExchangeRateFundResultViewModel(
				ExchangeRate: exchangeRate,
				Amount: decimal.Round(amount / exchangeRate, 6, MidpointRounding.ToZero));
	}

	[HttpGet]
	public IEnumerable<GameProviderExchangeRate> List()
		=> _gameProviderExchangeRateService.GetExchangeRates();
}
