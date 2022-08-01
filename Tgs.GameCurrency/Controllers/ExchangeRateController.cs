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
	/// Converts the game provider funds.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="amount">The amount.</param>
	/// <returns></returns>
	[HttpGet("gameprovider/funds", Name = "ConvertGameProviderFunds")]
	public ConvertGameProviderFundsResult ConvertGameProviderFunds(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromQuery] decimal amount)
	{
		var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return new ConvertGameProviderFundsResult(
					ExchangeRate: exchangeRate,
					Amount: _gameProviderExchangeRateService.ConvertGameProviderFunds(exchangeRate, amount));
	}

	/// <summary>
	/// Converts the game provider rounds.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="request">The request.</param>
	/// <returns></returns>
	[HttpPost("gameprovider/rounds", Name = "ConvertGameProviderRounds")]
	public ConvertGameProviderRoundsResult ConvertGameProviderRounds(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromBody] ConvertGameProviderRoundsRequest request)
	{
		var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return new ConvertGameProviderRoundsResult(
					ExchangeRate: exchangeRate,
					BetAmount: _gameProviderExchangeRateService.ConvertGameProviderRounds(exchangeRate, request.BetAmount.GetValueOrDefault(0)),
					ValidBetAmount: _gameProviderExchangeRateService.ConvertGameProviderRounds(exchangeRate, request.ValidBetAmount.GetValueOrDefault(0)),
					SettleAmount: _gameProviderExchangeRateService.ConvertGameProviderRounds(exchangeRate, request.SettleAmount.GetValueOrDefault(0)),
					Commission: _gameProviderExchangeRateService.ConvertGameProviderRounds(exchangeRate, request.Commission.GetValueOrDefault(0)),
					Turnover: _gameProviderExchangeRateService.ConvertGameProviderRounds(exchangeRate, request.Turnover.GetValueOrDefault(0)),
					WinLoss: _gameProviderExchangeRateService.ConvertGameProviderRounds(exchangeRate, request.WinLoss.GetValueOrDefault(0)));
	}

	/// <summary>
	/// Converts the platform balance.
	/// </summary>
	/// <param name="gameProviderCode">The game provider code.</param>
	/// <param name="currencyCode">The currency code.</param>
	/// <param name="balance">The balance.</param>
	/// <returns></returns>
	[HttpGet("platform/balance", Name = "ConvertPlatformBalance")]
	public ConvertPlatformBalanceResult ConvertPlatformBalance(
		[FromQuery] string gameProviderCode,
		[FromQuery] string currencyCode,
		[FromQuery] decimal balance)
	{
		var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

		return new ConvertPlatformBalanceResult(
					ExchangeRate: exchangeRate,
					Balance: _gameProviderExchangeRateService.ConvertPlatformBalance(exchangeRate, balance));
	}

	[HttpGet]
	public IEnumerable<GameProviderExchangeRate> List()
		=> _gameProviderExchangeRateService.GetExchangeRates();
}
