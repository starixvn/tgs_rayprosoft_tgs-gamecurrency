using FluentAssertions;
using Tgs.GameCurrency.Client;

namespace Tgs.GameCurrency.IntegrationTests;

public partial class GameCurrencyClientUnitTest
{
    [TestMethod]
    public async Task GameProvider_CNY_Game_Round_Conversion_Platform_CNY()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "CNY";
        var request = new ConvertPlatformRoundsRequest(
            Bet: 1,
            ValidBet: 1,
            Settle: 2,
            Commission: 1,
            Turnover: 1,
            WinLoss: 1);

        var expected = new ConvertPlatformRoundsResult(
            ExchangeRate: 1,
            Bet: 1,
            ValidBet: 1,
            Settle: 2,
            Commission: 1,
            Turnover: 1,
            WinLoss: 1);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformRoundsAsync(
            gameProviderCode,
            currencyCode,
            request).ConfigureAwait(false);

        Assert.IsNotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [TestMethod]
    public async Task GameProvider_IDR_Game_Round_Conversion_Platform_IDR1000()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR_1000";
        var request = new ConvertPlatformRoundsRequest(
            Bet: 1,
            ValidBet: 1,
            Settle: 2,
            Commission: 1,
            Turnover: 1,
            WinLoss: 1);

        var expected = new ConvertPlatformRoundsResult(
            ExchangeRate: 0.001m,
            Bet: 0.001m,
            ValidBet: 0.001m,
            Settle: 0.002m,
            Commission: 0.001m,
            Turnover: 0.001m,
            WinLoss: 0.001m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformRoundsAsync(
            gameProviderCode,
            currencyCode,
            request).ConfigureAwait(false);

        Assert.IsNotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [TestMethod]
    public async Task GameProvider_IDR1000_Game_Round_Conversion_Platform_IDR()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR";
        var request = new ConvertPlatformRoundsRequest(
            Bet: 1,
            ValidBet: 1,
            Settle: 2,
            Commission: 1,
            Turnover: 1,
            WinLoss: 1);

        var expected = new ConvertPlatformRoundsResult(
            ExchangeRate: 1000,
            Bet: 1000,
            ValidBet: 1000,
            Settle: 2000,
            Commission: 1000,
            Turnover: 1000,
            WinLoss: 1000);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformRoundsAsync(
            gameProviderCode,
            currencyCode,
            request).ConfigureAwait(false);

        Assert.IsNotNull(actual);
        _ = expected.Should().Be(actual);
    }
}
