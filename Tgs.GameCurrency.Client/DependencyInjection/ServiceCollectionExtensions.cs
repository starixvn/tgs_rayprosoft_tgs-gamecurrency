using Tgs.GameCurrency.Client;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGameCurrencyClient(this IServiceCollection services, Action<IHttpClientBuilder> httpClientConfigure)
	{
		httpClientConfigure(services.AddHttpClient<IGameCurrencyClient, GameCurrencyClient>());

		return services;
	}
}
