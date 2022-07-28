using Microsoft.Extensions.Options;
using Tgs.GameCurrency.Client;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGameRoundsClient(
		this IServiceCollection services,
		Action<GameCurrencyClientOptions, IServiceProvider> configure)
		=> services
			.AddOptions<GameCurrencyClientOptions>()
			.Configure(configure)
			.Services
			.AddHttpClient<IGameCurrencyClient, GameCurrencyClient>()
			.ConfigureHttpClient((sp, httpClient) =>
			{
				var options = sp.GetRequiredService<IOptions<GameCurrencyClientOptions>>().Value;
				httpClient.BaseAddress = options.BaseUrl;
			})
			.AddHttpMessageHandler<LoggingHandler>()
			.Services
			.AddTransient<LoggingHandler>();
}
