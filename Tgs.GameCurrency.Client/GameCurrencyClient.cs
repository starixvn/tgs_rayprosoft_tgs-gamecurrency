using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace Tgs.GameCurrency.Client
{
	internal class GameCurrencyClient : IGameCurrencyClient
	{
		private static readonly JsonSerializerOptions _SerializerOptions = new()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			Converters =
			{
				new JsonStringEnumConverter()
			}
		};

		private readonly HttpClient _httpClient;

		public GameCurrencyClient(HttpClient httpClient)
		  => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

		public async ValueTask<ExchangeRateBalanceResultViewModel> GetExchangeRateBalanceAsync(
			string gameProviderCode,
			string currencyCode,
			decimal balance,
			CancellationToken cancellationToken = default)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["gameProviderCode"] = gameProviderCode;
			query["currencyCode"] = currencyCode;
			query["balance"] = balance.ToString();

			var requestUri = $"exchangerate/balance?{query}";

			var response = await _httpClient
				.GetAsync(
				   requestUri: requestUri,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return JsonSerializer.Deserialize<ExchangeRateBalanceResultViewModel>(contentJson, _SerializerOptions)!;
		}

		public async ValueTask<ExchangeRateFundResultViewModel> GetExchangeRateFundInAsync(
			string gameProviderCode,
			string currencyCode,
			decimal amount,
			CancellationToken cancellationToken = default)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["gameProviderCode"] = gameProviderCode;
			query["currencyCode"] = currencyCode;
			query["amount"] = amount.ToString();

			var requestUri = $"exchangerate/fund/in?{query}";

			var response = await _httpClient
				.GetAsync(
				   requestUri: requestUri,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return JsonSerializer.Deserialize<ExchangeRateFundResultViewModel>(contentJson, _SerializerOptions)!;
		}

		public async ValueTask<ExchangeRateFundResultViewModel> GetExchangeRateFundOutAsync(
			string gameProviderCode,
			string currencyCode,
			decimal amount,
			CancellationToken cancellationToken = default)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["gameProviderCode"] = gameProviderCode;
			query["currencyCode"] = currencyCode;
			query["amount"] = amount.ToString();

			var requestUri = $"exchangerate/fund/out?{query}";

			var response = await _httpClient
				.GetAsync(
				   requestUri: requestUri,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return JsonSerializer.Deserialize<ExchangeRateFundResultViewModel>(contentJson, _SerializerOptions)!;
		}
	}
}
