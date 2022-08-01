using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Exporter;
using Tgs.GameCurrency.Client;

namespace Tgs.GameCurrency.IntegrationTests;

[TestClass]
public class GameCurrencyClientUnitTest
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

		var actual = await sut.ConvertPlatformBalance(
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

		var actual = await sut.ConvertPlatformBalance(
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

		var actual = await sut.ConvertPlatformBalance(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

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

		var actual = await sut.ConvertGameProviderFunds(
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

		var actual = await sut.ConvertGameProviderFunds(
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

		var actual = await sut.ConvertGameProviderFunds(
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

		var actual = await sut.ConvertGameProviderFunds(
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

		var actual = await sut.ConvertGameProviderFunds(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	private static WebApplicationFactory<Program> CreateTestSettingSite(Action<IServiceCollection>? configureServices = null)
		=> new GameCurrencyApplicationUnitTest(hostBuilder =>
		{
			_ = hostBuilder
			.ConfigureAppConfiguration((_, configBuilder) =>
			{
				configBuilder.Sources.Clear();
			})
			.ConfigureServices(services =>
			{
				_ = services
				.AddSingleton<IConfigureOptions<OtlpExporterOptions>>(
					sp => new ConfigureNamedOptions<OtlpExporterOptions>(
						Options.DefaultName,
						exporterOptions =>
						{
							exporterOptions.TimeoutMilliseconds = 0;
						}))
				.AddSingleton<IConfigureOptions<GameCurrencySettingsOption>>(
					sp => new ConfigureNamedOptions<GameCurrencySettingsOption>(
						Options.DefaultName,
						exporterOptions =>
						{
							exporterOptions.GameProviderExchangeRates = new GameProviderExchangeRate[]
							{
								new GameProviderExchangeRate()
								{
									GameProviderCode="AWC_PGS",
									CurrencyCode="IDR",
									ExchangeRate=1000
								},
								new GameProviderExchangeRate()
								{
									GameProviderCode="AWC_PGS",
									CurrencyCode="IDR_1000",
									ExchangeRate=0.001m
								}
							};
						}));
				configureServices?.Invoke(services);
			});
		});
}
