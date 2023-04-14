using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Exporter;

namespace Tgs.GameCurrency.IntegrationTests;

public partial class GameCurrencyClientUnitTest
{
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
