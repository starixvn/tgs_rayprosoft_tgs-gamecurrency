using Tgs.GameCurrency.Client;
using Tgs.GameCurrency.IntegrationTest;

namespace Tgs.GameCurrency.IntegrationTest;

public partial class GameCurrencyClientUnitTest
{
	[Fact]
	public async Task GetExchangeRate_CNY_Game_Round_Conversion_Platform_CNY()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "CNY";

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRate(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode);

		Assert.Equal(1.0m, actual);
	}

	[Fact]
	public async Task GetExchangeRate_IDR_Game_Round_Conversion_Platform_IDR1000()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRate(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode);

		Assert.Equal(0.001m, actual);
	}

	[Fact]
	public async Task GetExchangeRate_IDR1000_Game_Round_Conversion_Platform_IDR()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRate(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode);

		Assert.Equal(1000m, actual);
	}
}
