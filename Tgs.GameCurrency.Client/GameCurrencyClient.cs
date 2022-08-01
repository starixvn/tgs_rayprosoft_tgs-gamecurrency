using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
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

		public async ValueTask<ConvertGameProviderFundsResult> ConvertGameProviderFunds(
			string gameProviderCode,
			string currencyCode,
			decimal amount,
			CancellationToken cancellationToken = default)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["gameProviderCode"] = gameProviderCode;
			query["currencyCode"] = currencyCode;
			query["amount"] = amount.ToString();

			var requestUri = $"exchangerate/gameprovider/funds?{query}";

			var response = await _httpClient
				.GetAsync(
				   requestUri: requestUri,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return JsonSerializer.Deserialize<ConvertGameProviderFundsResult>(contentJson, _SerializerOptions)!;
		}

		public async ValueTask<ConvertGameProviderRoundsResult> ConvertGameProviderRounds(
			string gameProviderCode,
			string currencyCode,
			ConvertGameProviderRoundsRequest request,
			CancellationToken cancellationToken = default)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["gameProviderCode"] = gameProviderCode;
			query["currencyCode"] = currencyCode;

			var requestUri = $"exchangerate/gameprovider/rounds?{query}";

			var requestContent = new StringContent(
				content: JsonSerializer.Serialize(request, _SerializerOptions),
				encoding: Encoding.UTF8,
				mediaType: MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json).MediaType);

			var response = await _httpClient
				.PostAsync(
				   requestUri: requestUri,
				   content: requestContent,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return JsonSerializer.Deserialize<ConvertGameProviderRoundsResult>(contentJson, _SerializerOptions)!;
		}

		public async ValueTask<ConvertPlatformBalanceResult> ConvertPlatformBalance(
			string gameProviderCode,
			string currencyCode,
			decimal balance,
			CancellationToken cancellationToken = default)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["gameProviderCode"] = gameProviderCode;
			query["currencyCode"] = currencyCode;
			query["balance"] = balance.ToString();

			var requestUri = $"exchangerate/platform/balance?{query}";

			var response = await _httpClient
				.GetAsync(
				   requestUri: requestUri,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return JsonSerializer.Deserialize<ConvertPlatformBalanceResult>(contentJson, _SerializerOptions)!;
		}
	}
}
