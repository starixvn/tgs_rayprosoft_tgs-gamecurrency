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
    public ConvertGameProviderFundsResultViewModel ConvertGameProviderFunds(
        [FromQuery] string gameProviderCode,
        [FromQuery] string currencyCode,
        [FromQuery] decimal amount)
    {
        var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

        return new ConvertGameProviderFundsResultViewModel(
                    ExchangeRate: exchangeRate,
                    Amount: _gameProviderExchangeRateService.ConvertGameProviderFunds(exchangeRate, amount));
    }

    /// <summary>
    /// Converts the platform balance.
    /// </summary>
    /// <param name="gameProviderCode">The game provider code.</param>
    /// <param name="currencyCode">The currency code.</param>
    /// <param name="balance">The balance.</param>
    /// <returns></returns>
    [HttpGet("platform/balance", Name = "ConvertPlatformBalance")]
    public ConvertPlatformBalanceResultViewModel ConvertPlatformBalance(
        [FromQuery] string gameProviderCode,
        [FromQuery] string currencyCode,
        [FromQuery] decimal balance)
    {
        var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

        return new ConvertPlatformBalanceResultViewModel(
                    ExchangeRate: exchangeRate,
                    Balance: _gameProviderExchangeRateService.ConvertPlatformBalance(exchangeRate, balance));
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
        var exchangeRate = _gameProviderExchangeRateService.GetExchangeRates(gameProviderCode, currencyCode);

        return new ConvertPlatformRoundsResultViewModel(
                    ExchangeRate: exchangeRate,
                    Bet: _gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Bet),
                    ValidBet: _gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.ValidBet),
                    Settle: _gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Settle),
                    Commission: _gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Commission),
                    Turnover: _gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.Turnover),
                    WinLoss: _gameProviderExchangeRateService.ConvertPlatformRounds(exchangeRate, model.WinLoss));
    }

    [HttpGet]
    public IEnumerable<GameProviderExchangeRate> List()
        => _gameProviderExchangeRateService.GetExchangeRates();
}
