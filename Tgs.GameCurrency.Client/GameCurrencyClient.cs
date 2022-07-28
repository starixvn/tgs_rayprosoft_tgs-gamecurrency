using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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

		public async ValueTask<decimal> GetExchangeRateFundInAsync(
			string gameProviderCode,
			string currencyCode,
			decimal amount,
			CancellationToken cancellationToken = default)
		{
			var request = new
			{
				gameProviderCode,
				currencyCode,
				amount
			};

			var content = new StringContent(JsonSerializer.Serialize(request, _SerializerOptions), encoding: Encoding.UTF8);
			content.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json);

			var response = await _httpClient
				.PostAsync(
				   requestUri: "exchangerate/fund-in",
				   content: content,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return decimal.Parse(contentJson);
		}

		public async ValueTask<decimal> GetExchangeRateFundOutAsync(
			string gameProviderCode,
			string currencyCode,
			decimal amount,
			CancellationToken cancellationToken = default)
		{
			var request = new
			{
				gameProviderCode,
				currencyCode,
				amount
			};

			var content = new StringContent(JsonSerializer.Serialize(request, _SerializerOptions), encoding: Encoding.UTF8);
			content.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Application.Json);

			var response = await _httpClient
				.PostAsync(
				   requestUri: "exchangerate/fund-out",
				   content: content,
				   cancellationToken: cancellationToken)
			   .ConfigureAwait(false);

			_ = response.EnsureSuccessStatusCode();

			var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

			return decimal.Parse(contentJson);
		}
	}
}
