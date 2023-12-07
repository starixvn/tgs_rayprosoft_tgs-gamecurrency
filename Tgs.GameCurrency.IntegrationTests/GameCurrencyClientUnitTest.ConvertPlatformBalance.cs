using FluentAssertions;
using Tgs.GameCurrency.Client;

namespace Tgs.GameCurrency.IntegrationTests;

public partial class GameCurrencyClientUnitTest
{
    [Fact]
    public async Task Game_Provider_Balance_CNY_Amount_1_Conversion_Platform_CNY_Amount_1()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "CNY";
        var balance = 10m;
        var freeBalance = 1m;
        var outstandingBalance = 9m;
        var expected = new ConvertPlatformBalanceResult(
            ExchangeRate: 1,
            Balance: balance,
            FreeBalance: freeBalance,
            OutstandingBalance: outstandingBalance);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformBalanceAsync(
            gameProviderCode: gameProviderCode,
            currencyCode: currencyCode,
            balance: balance,
            freeBalance: freeBalance,
            outstandingBalance: outstandingBalance);

        Assert.NotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [Fact]
    public async Task Game_Provider_Balance_IDR_Amount_1_Conversion_Platform_IDR1000_Amount_1000()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR";
        var balance = 10m;
        var freeBalance = 1m;
        var outstandingBalance = 9m;
        var expected = new ConvertPlatformBalanceResult(
            ExchangeRate: 1000,
            Balance: 10000m,
            FreeBalance: 1000m,
            OutstandingBalance: 9000m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformBalanceAsync(
            gameProviderCode: gameProviderCode,
            currencyCode: currencyCode,
            balance: balance,
            freeBalance: freeBalance,
            outstandingBalance: outstandingBalance);

        Assert.NotNull(actual);
        _ = expected.Should().Be(actual);
    }

    [Fact]
    public async Task Game_Provider_Balance_IDR1000_Amount_1_Conversion_Platform_IDR_Amount_0001M()
    {
        var gameProviderCode = "AWC_PGS";
        var currencyCode = "IDR_1000";
        var balance = 10m;
        var freeBalance = 1m;
        var outstandingBalance = 9m;
        var expected = new ConvertPlatformBalanceResult(
            ExchangeRate: 0.001m,
            Balance: 0.01m,
            FreeBalance: 0.001m,
            OutstandingBalance: 0.009m);

        var web = CreateTestSettingSite();

        var httpClient = web.CreateClient();

        var sut = new GameCurrencyClient(httpClient);

        var actual = await sut.ConvertPlatformBalanceAsync(
            gameProviderCode: gameProviderCode,
            currencyCode: currencyCode,
            balance: balance,
            freeBalance: freeBalance,
            outstandingBalance: outstandingBalance);

        Assert.NotNull(actual);
        _ = expected.Should().Be(actual);
    }
}
