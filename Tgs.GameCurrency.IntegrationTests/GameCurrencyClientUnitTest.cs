using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Exporter;
using Tgs.GameCurrency.Client;

namespace Tgs.GameCurrency.IntegrationTests;

[TestClass]
public class GameCurrencyClientUnitTest
{
	[TestMethod]
	public async Task Exchange_Rate_Conversion_To_Transfer_Funds_Out_Of_The_Game_Provider_Has_Settings()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 10000m;
		var expected = 10m;

		var web = CreateTestSettingSite(service =>
		{
			_ = service.AddSingleton<IConfigureOptions<GameCurrencySettingsOption>>(
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
								}
							};
						}));
		});

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundOut(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public async Task Exchange_Rate_Conversion_To_Transfer_Funds_Out_Of_The_Game_Provider_Is_Not_Settings()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 10000m;
		var expected = 10000m;

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundOut(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public async Task Exchange_Rate_Conversion_To_Transfer_Funds_In_Of_The_Game_Provider_Has_Settings()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 1m;
		var expected = 1000m;

		var web = CreateTestSettingSite(service =>
		{
			_ = service.AddSingleton<IConfigureOptions<GameCurrencySettingsOption>>(
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
								}
							};
						}));
		});

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundIn(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public async Task Exchange_Rate_Conversion_To_Transfer_Funds_In_Of_The_Game_Provider_Is_Not_Settings()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var amount = 1m;
		var expected = 1m;

		var web = CreateTestSettingSite();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.GetExchangeRateFundIn(
			gameProviderCode,
			currencyCode,
			amount).ConfigureAwait(false);

		Assert.IsNotNull(actual);
		Assert.AreEqual(expected, actual);
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
						}));
				configureServices?.Invoke(services);
			});
		});
}