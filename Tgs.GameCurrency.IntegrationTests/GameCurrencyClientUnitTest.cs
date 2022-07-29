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
	public async Task Platform_Currency_CNY_1_Gets_Balance_Game_Provider_IDR_Balance_Has_1_To_Get_Balance_1()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "CNY";
		var amount = 1m;
		var expected = new ExchangeRateBalanceResultViewModel(
			ExchangeRate: 1,
			Balance: 1);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateBalanceAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_CNY_Amount_1_FundIn_Game_Provider_CNY_To_Get_An_Amount_1()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "CNY";
		var amount = 1m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 1,
			Amount: 1);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundInAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_CNY_Amount_1_FundOut_Game_Provider_CNY_To_Get_An_Amount_1()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "CNY";
		var amount = 10000m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 1,
			Amount: 10000m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundOutAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_1000_Amount_001M_FundIn_Game_Provider_IDR_To_Get_An_Amount_000001M()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var amount = 0.01m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 0.001m,
			Amount: 0.00001m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundInAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_1000_Amount_001m_FundOut_Game_Provider_IDR_To_Get_An_Amount_10()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var amount = 0.01m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 0.001m,
			Amount: 10);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundOutAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_1000_Amount_1_FundIn_Game_Provider_IDR_To_Get_An_Amount_0001M()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var amount = 1m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 0.001m,
			Amount: 0.001m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundInAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_1000_Amount_1_FundOut_Game_Provider_IDR_To_Get_An_Amount_1000()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var amount = 1m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 0.001m,
			Amount: 1000);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundOutAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_1000_Gets_Balance_Game_Provider_IDR_Balance_Has_1_To_Get_Balance_0001m()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var amount = 1m;
		var expected = new ExchangeRateBalanceResultViewModel(
			ExchangeRate: 0.001m,
			Balance: 0.001m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateBalanceAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_Amount_001m_FundIn_Game_Provider_IDR_1000_To_Get_An_Amount_10()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 0.01m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 1000,
			Amount: 10);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundInAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_Amount_001M_FundOut_Game_Provider_IDR_1000_To_Get_An_Amount_000001M()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 0.01m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 1000,
			Amount: 0.00001m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundOutAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_Amount_1_FundIn_Game_Provider_IDR_1000_To_Get_An_Amount_1000()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 1m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 1000,
			Amount: 1000);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundInAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_Amount_1_FundOut_Game_Provider_IDR_1000_To_Get_An_Amount_0001M()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 1m;
		var expected = new ExchangeRateFundResultViewModel(
			ExchangeRate: 1000,
			Amount: 0.001m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundOutAsync(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[TestMethod]
	public async Task Platform_Currency_IDR_Gets_Balance_Game_Provider_IDR_1000_Balance_Has_1_To_Get_Balance_1000()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 1m;
		var expected = new ExchangeRateBalanceResultViewModel(
			ExchangeRate: 1000,
			Balance: 1000m);

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateBalanceAsync(
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
