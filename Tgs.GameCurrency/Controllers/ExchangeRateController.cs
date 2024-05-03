using Microsoft.AspNetCore.Mvc;
using Tgs.GameCurrency.ViewModels;

namespace Tgs.GameCurrency.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController(IGameProviderExchangeRateUtensil gameProviderExchangeRateService) : ControllerBase
{
	/// <summary>
	/// Converts the game provider funds.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="amount">The amount.</param>
	/// <returns></returns>
	[HttpGet("gameprovider/funds", Name = "ConvertGameProviderFunds")]
	public ConvertGameProviderFundsResultViewModel ConvertGameProviderFunds(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromQuery] decimal amount)
	{
		var exchangeRate = gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return new ConvertGameProviderFundsResultViewModel(
			ExchangeRate: exchangeRate,
			Amount: gameProviderExchangeRateService.ConvertGameProviderFunds(exchangeRate, amount));
	}

	/// <summary>
	/// Converts the platform balance.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="balance">The balance.</param>
	/// <param name="freeBalance">The free balance.</param>
	/// <param name="outstandingBalance">The outstanding balance.</param>
	/// <returns></returns>
	[HttpGet("platform/balance", Name = "ConvertPlatformBalance")]
	public ConvertPlatformBalanceResultViewModel ConvertPlatformBalance(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromQuery] decimal balance,
		[FromQuery] decimal freeBalance,
		[FromQuery] decimal outstandingBalance)
	{
		var exchangeRate = gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return new ConvertPlatformBalanceResultViewModel(
			ExchangeRate: exchangeRate,
			Balance: gameProviderExchangeRateService.ConvertPlatformBalance(exchangeRate, balance),
			FreeBalance: gameProviderExchangeRateService.ConvertPlatformBalance(exchangeRate, freeBalance),
			OutstandingBalance: gameProviderExchangeRateService.ConvertPlatformBalance(exchangeRate, outstandingBalance));
	}

	/// <summary>
	/// Converts the platform rounds.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="model">The model.</param>
	/// <returns></returns>
	[HttpPost("platform/rounds", Name = "ConvertPlatformRounds")]
	public ConvertPlatformRoundsResultViewModel ConvertPlatformRounds(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromBody] ConvertPlatformRoundsRequestViewModel model)
	{
		var exchangeRate = gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return new ConvertPlatformRoundsResultViewModel(
			ExchangeRate: exchangeRate,
			Bet: gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Bet),
			ValidBet: gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.ValidBet),
			Settle: gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Settle),
			Commission: gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Commission),
			Turnover: gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Turnover),
			WinLoss: gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.WinLoss),
			Jackpot: gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Jackpot));
	}

	/// <summary>
	/// Gets the exchange rate.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <returns></returns>
	[HttpGet("{gameProviderCode}/{currencyCode}", Name = "Get_ExchangeRates")]
	public decimal GetExchangeRate(
		string gameProviderCode,
		string currencyCode)
		=> gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

	[HttpGet]
	public IEnumerable<GameProviderExchangeRate> List()
		=> gameProviderExchangeRateService.GetExchangeRates();
}
