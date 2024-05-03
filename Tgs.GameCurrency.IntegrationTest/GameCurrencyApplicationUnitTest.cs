using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Exporter;

namespace Tgs.GameCurrency.IntegrationTest;

internal class GameCurrencyApplicationUnitTest(Action<IWebHostBuilder>? webHostConfigure = null) : WebApplicationFactory<Program>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		_ = builder
			.ConfigureAppConfiguration(c => c.Sources.Clear())
			.ConfigureServices(services => _ = services
			.AddSingleton<IConfigureOptions<OtlpExporterOptions>>(
				sp => new ConfigureNamedOptions<OtlpExporterOptions>(
					Options.DefaultName,
					exporterOptions => exporterOptions.TimeoutMilliseconds = 0))
			.AddSingleton<IConfigureOptions<GameCurrencySettingsOption>>(
				sp => new ConfigureNamedOptions<GameCurrencySettingsOption>(
					Options.DefaultName,
					exporterOptions => exporterOptions.GameProviderExchangeRates = new GameProviderExchangeRate[]
					{
						new()
						{
							GameProviderCode="AWC_PGS",
							CurrencyCode="IDR",
							ExchangeRate=1000
						},
						new()
						{
							GameProviderCode="AWC_PGS",
							CurrencyCode="IDR_1000",
							ExchangeRate=0.001m
						}
					})));
		webHostConfigure?.Invoke(builder);
	}
}
