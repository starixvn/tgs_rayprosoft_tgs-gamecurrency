using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace Tgs.GameCurrency.Client;

internal class GameCurrencyClient(HttpClient httpClient) : IGameCurrencyClient
{
	private static readonly JsonSerializerOptions _SerializerOptions = new()
	{
		// Gets or sets a value that specifies the policy used to convert a property's name on an object to another format, such as camel-casing, or null to leave property names unchanged.
		// Gets the naming policy for camel-casing.
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

		// Gets or sets a value that indicates whether JSON should use pretty printing. By default, JSON is serialized without any extra white space.
		WriteIndented = false,

		// Always				1	Property will always be ignored.
		// Never				0	Property will always be serialized and deserialized,regardless of IgnoreNullValues configuration.
		// WhenWritingDefault	2	Property will only be ignored if it is null.
		// WhenWritingNull		3	If the value is null,the property is ignored during serialization.This is applied only to reference - type properties and fields.
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,

		Converters =
		{
				// Converts enumeration values to and from strings.
				new JsonStringEnumConverter()
		}
	};

	public async ValueTask<Common.ConvertGameProviderFundsResult> ConvertGameProviderFundsAsync(string gameProviderCode, string currencyCode, decimal amount, CancellationToken cancellationToken = default)
	{
		var query = HttpUtility.ParseQueryString(string.Empty);
		query["gameProviderCode"] = gameProviderCode;
		query["currencyCode"] = currencyCode;
		query["amount"] = amount.ToString();

		var requestUri = $"exchangerate/gameprovider/funds?{query}";

		var response = await httpClient.GetAsync(
			requestUri: requestUri,
			cancellationToken: cancellationToken)
		   .ConfigureAwait(false);

		_ = response.EnsureSuccessStatusCode();

		var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

		return JsonSerializer.Deserialize<Common.ConvertGameProviderFundsResult>(contentJson, _SerializerOptions)!;
	}

	public async ValueTask<Common.ConvertPlatformBalanceResult> ConvertPlatformBalanceAsync(string gameProviderCode, string currencyCode, decimal balance, decimal freeBalance, decimal outstandingBalance, CancellationToken cancellationToken = default)
	{
		var query = HttpUtility.ParseQueryString(string.Empty);
		query["gameProviderCode"] = gameProviderCode;
		query["currencyCode"] = currencyCode;
		query["balance"] = balance.ToString();
		query["freeBalance"] = freeBalance.ToString();
		query["outstandingBalance"] = outstandingBalance.ToString();

		var requestUri = $"exchangerate/platform/balance?{query}";

		var response = await httpClient.GetAsync(
			requestUri: requestUri,
			cancellationToken: cancellationToken)
		   .ConfigureAwait(false);

		_ = response.EnsureSuccessStatusCode();

		var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

		return JsonSerializer.Deserialize<Common.ConvertPlatformBalanceResult>(contentJson, _SerializerOptions)!;
	}

	public async ValueTask<Common.ConvertPlatformRoundsResult> ConvertPlatformRoundsAsync(string gameProviderCode, string currencyCode, decimal bet, decimal validBet, decimal settle, decimal winLoss, decimal turnover, decimal commission, decimal contribute, decimal jackpot, CancellationToken cancellationToken = default)
	{
		var query = HttpUtility.ParseQueryString(string.Empty);
		query["gameProviderCode"] = gameProviderCode;
		query["currencyCode"] = currencyCode;

		var request = new
		{
			Bet = bet,
			ValidBet = validBet,
			Settle = settle,
			WinLoss = winLoss,
			Turnover = turnover,
			Commission = commission,
			Contribute = contribute,
			Jackpot = jackpot,
		};

		var requestUri = $"exchangerate/platform/rounds?{query}";

		var requestContent = JsonContent.Create(request, options: _SerializerOptions);

		var response = await httpClient.PostAsync(
			requestUri: requestUri,
			content: requestContent,
			cancellationToken: cancellationToken)
			.ConfigureAwait(false);

		_ = response.EnsureSuccessStatusCode();

		var contentJson = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

		return JsonSerializer.Deserialize<Common.ConvertPlatformRoundsResult>(contentJson, _SerializerOptions)!;
	}

	public async ValueTask<decimal> GetExchangeRate(string gameProviderCode, string currencyCode, CancellationToken cancellationToken = default)
	{
		var path = new Uri(httpClient.BaseAddress!, $"/exchangerate/{gameProviderCode}/{currencyCode}");
		var builder = new UriBuilder(path);
		var query = HttpUtility.ParseQueryString(builder.Query);

		builder.Query = query.ToString();
		string url = builder.ToString();

		var response = await httpClient.GetAsync(
			requestUri: url.ToString(),
			cancellationToken: cancellationToken)
			.ConfigureAwait(false);

		_ = response.EnsureSuccessStatusCode();

		return await response.Content.ReadFromJsonAsync<decimal>(
			_SerializerOptions,
			cancellationToken).ConfigureAwait(false);
	}
}
