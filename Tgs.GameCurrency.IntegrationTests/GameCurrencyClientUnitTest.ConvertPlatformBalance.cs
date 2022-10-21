using FluentAssertions;
using Tgs.GameCurrency.Client;

namespace Tgs.GameCurrency.IntegrationTests;

public partial class GameCurrencyClientUnitTest
{
    [TestMethod]
    public async Task Game_Provider_Balance_CNY_Amount_1_Conversion_Platform_CNY_Amount_1()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "CNY";
        var amount = 1m;
        var expected = new ConvertPlatformBalanceResult(
            ExchangeRate: 1,
            Balance: 1);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformBalanceAsync(
            gameProviderCode,
            currencyCode,
            amount).ConfigureAwait(false);

        Assert.IsNotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [TestMethod]
    public async Task Game_Provider_Balance_IDR_Amount_1_Conversion_Platform_IDR1000_Amount_1000()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR";
        var amount = 1m;
        var expected = new ConvertPlatformBalanceResult(
            ExchangeRate: 1000,
            Balance: 1000m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformBalanceAsync(
            gameProviderCode,
            currencyCode,
            amount).ConfigureAwait(false);

        Assert.IsNotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [TestMethod]
    public async Task Game_Provider_Balance_IDR1000_Amount_1_Conversion_Platform_IDR_Amount_0001M()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR_1000";
        var amount = 1m;
        var expected = new ConvertPlatformBalanceResult(
            ExchangeRate: 0.001m,
            Balance: 0.001m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformBalanceAsync(
            gameProviderCode,
            currencyCode,
            amount).ConfigureAwait(false);

        Assert.IsNotNull(actual);
        _ = expected.Should().Be(actual);
    }
}
