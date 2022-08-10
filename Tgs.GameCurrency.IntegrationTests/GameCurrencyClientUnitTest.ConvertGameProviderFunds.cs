using FluentAssertions;
using Tgs.GameCurrency.Client;

namespace Tgs.GameCurrency.IntegrationTests;

public partial class GameCurrencyClientUnitTest
{
	[TestMethod]
	public async Task Platform_Fund_CNY_Amount_1_Convert_Game_Provider_CNY_Amount_1()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "CNY";
		var amount = 1m;
		var expected = new ConvertGameProviderFundsResult(
			ExchangeRate: 1,
			Amount: 1m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertGameProviderFundsAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Fund_IDR_Amount_001M_Convert_Game_Provider_IDR1000_Amount_000001M()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 0.01m;
		var expected = new ConvertGameProviderFundsResult(
			ExchangeRate: 1000,
			Amount: 0.00001m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertGameProviderFundsAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Fund_IDR_Amount_1_Convert_Game_Provider_IDR1000_Amount_0001M()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 1m;
		var expected = new ConvertGameProviderFundsResult(
			ExchangeRate: 1000,
			Amount: 0.001m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertGameProviderFundsAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Fund_IDR1000_Amount_001_Convert_Game_Provider_IDR_Amount_10()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var amount = 0.01m;
		var expected = new ConvertGameProviderFundsResult(
			ExchangeRate: 0.001m,
			Amount: 10m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertGameProviderFundsAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Fund_IDR1000_Amount_1_Convert_Game_Provider_IDR_Amount_1000()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var amount = 1;
		var expected = new ConvertGameProviderFundsResult(
			ExchangeRate: 0.001m,
			Amount: 1000m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertGameProviderFundsAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}
}
