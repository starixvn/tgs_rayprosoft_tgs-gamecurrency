using FluentAssertions;
using Tgs.GameCurrency.Client;

namespace Tgs.GameCurrency.IntegrationTests;

public partial class GameCurrencyClientUnitTest
{
    [Fact]
    public async Task GameProvider_CNY_Game_Round_Conversion_Platform_CNY()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "CNY";
        var bet = 10.0m;
        var validBet = 5.0m;
        var settle = 2.5m;
        var commission = 0.15m;
        var turnover = 1m;
        var winLoss = -2.5m;

        var expected = new ConvertPlatformRoundsResult(
            ExchangeRate: 1,
            Bet: 10.0m,
            ValidBet: 5.0m,
            Settle: 2.5m,
            Commission: 0.15m,
            Turnover: 1m,
            WinLoss: -2.5m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformRoundsAsync(
            gameProviderCode: gameProviderCode,
            currencyCode: currencyCode,
            bet: bet,
            validBet: validBet,
            settle: settle,
            commission: commission,
            turnover: turnover,
            winLoss: winLoss);

        Assert.NotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [Fact]
    public async Task GameProvider_IDR_Game_Round_Conversion_Platform_IDR1000()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR_1000";
        var bet = 10.0m;
        var validBet = 5.0m;
        var settle = 2.5m;
        var commission = 0.15m;
        var turnover = 1m;
        var winLoss = -2.5m;

        var expected = new ConvertPlatformRoundsResult(
            ExchangeRate: 0.001m,
            Bet: 0.01m,
            ValidBet: 0.005m,
            Settle: 0.0025m,
            Commission: 0.00015m,
            Turnover: 0.001m,
            WinLoss: -0.0025m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformRoundsAsync(
            gameProviderCode: gameProviderCode,
            currencyCode: currencyCode,
            bet: bet,
            validBet: validBet,
            settle: settle,
            commission: commission,
            turnover: turnover,
            winLoss: winLoss);

        Assert.NotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [Fact]
    public async Task GameProvider_IDR1000_Game_Round_Conversion_Platform_IDR()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR";
        var bet = 10.0m;
        var validBet = 5.0m;
        var settle = 2.5m;
        var commission = 0.15m;
        var turnover = 1m;
        var winLoss = -2.5m;

        var expected = new ConvertPlatformRoundsResult(
            ExchangeRate: 1000m,
            Bet: 10000m,
            ValidBet: 5000m,
            Settle: 2500m,
            Commission: 150m,
            Turnover: 1000m,
            WinLoss: -2500m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformRoundsAsync(
            gameProviderCode: gameProviderCode,
            currencyCode: currencyCode,
            bet: bet,
            validBet: validBet,
            settle: settle,
            commission: commission,
            turnover: turnover,
            winLoss: winLoss);

        Assert.NotNull(actual);
        _ = expected.Should().Be(actual);
    }
}
