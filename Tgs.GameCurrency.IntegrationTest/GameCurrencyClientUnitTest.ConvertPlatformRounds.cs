using FluentAssertions;
using Tgs.GameCurrency.Client;
using Tgs.GameCurrency.IntegrationTest;

namespace Tgs.GameCurrency.IntegrationTest;

public partial class GameCurrencyClientUnitTest
{
	[Fact]
	public async Task GameProvider_CNY_Game_Round_Conversion_Platform_CNY()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "CNY";
		var bet = 10.0m;
		var validBet = 5.0m;
		var settle = 2.5m;
		var winLoss = -2.5m;
		var turnover = 1m;
		var commission = 0.15m;
		var contribute = 0.015m;
		var jackpot = 0.0m;

		var expected = new Common.ConvertPlatformRoundsResult(
			ExchangeRate: 1,
			Bet: 10.0m,
			ValidBet: 5.0m,
			Settle: 2.5m,
			WinLoss: -2.5m,
			Turnover: 1m,
			Commission: 0.15m,
			Contribute: 0.015m,
			Jackpot: 0.000m);

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertPlatformRoundsAsync(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode,
			bet: bet,
			validBet: validBet,
			settle: settle,
			winLoss: winLoss,
			turnover: turnover,
			commission: commission,
			contribute: contribute,
			jackpot: jackpot);

		Assert.NotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[Fact]
	public async Task GameProvider_IDR_Game_Round_Conversion_Platform_IDR1000()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR_1000";
		var bet = 10.0m;
		var validBet = 5.0m;
		var settle = 2.5m;
		var winLoss = -2.5m;
		var turnover = 1m;
		var commission = 0.15m;
		var contribute = 0.015m;
		var jackpot = 0.0m;

		var expected = new Common.ConvertPlatformRoundsResult(
			ExchangeRate: 0.001m,
			Bet: 0.01m,
			ValidBet: 0.005m,
			Settle: 0.0025m,
			WinLoss: -0.0025m,
			Turnover: 0.001m,
			Commission: 0.00015m,
			Contribute: 0.000015m,
			Jackpot: 0.000m);

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertPlatformRoundsAsync(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode,
			bet: bet,
			validBet: validBet,
			settle: settle,
			winLoss: winLoss,
			turnover: turnover,
			commission: commission,
			contribute: contribute,
			jackpot: jackpot);

		Assert.NotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[Fact]
	public async Task GameProvider_IDR1000_Game_Round_Conversion_Platform_IDR()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var bet = 10.0m;
		var validBet = 5.0m;
		var settle = 2.5m;
		var winLoss = -2.5m;
		var turnover = 1m;
		var commission = 0.15m;
		var contribute = 0.015m;
		var jackpot = 0.0m;

		var expected = new Common.ConvertPlatformRoundsResult(
			ExchangeRate: 1000m,
			Bet: 10000m,
			ValidBet: 5000m,
			Settle: 2500m,
			WinLoss: -2500m,
			Turnover: 1000m,
			Commission: 150m,
			Contribute: 15m,
			Jackpot: 0.000m);

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertPlatformRoundsAsync(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode,
			bet: bet,
			validBet: validBet,
			settle: settle,
			winLoss: winLoss,
			turnover: turnover,
			commission: commission,
			contribute: contribute,
			jackpot: jackpot);

		Assert.NotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[Fact]
	public async Task Jackpot_GameProvider_CNY_Game_Round_Conversion_Platform_CNY()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "CNY";
		var bet = 10.0m;
		var validBet = 5.0m;
		var settle = 12.5m;
		var winLoss = 7.5m;
		var turnover = 1m;
		var commission = 0.15m;
		var contribute = 0.015m;
		var jackpot = 2.5m;

		var expected = new Common.ConvertPlatformRoundsResult(
			ExchangeRate: 1,
			Bet: 10.0m,
			ValidBet: 5.0m,
			Settle: 12.5m,
			WinLoss: 7.5m,
			Turnover: 1m,
			Commission: 0.15m,
			Contribute: 0.015m,
			Jackpot: 2.5m);

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertPlatformRoundsAsync(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode,
			bet: bet,
			validBet: validBet,
			settle: settle,
			winLoss: winLoss,
			turnover: turnover,
			commission: commission,
			contribute: contribute,
			jackpot: jackpot);

		Assert.NotNull(actual);
		_ = expected.Should().Be(actual);
	}

	[Fact]
	public async Task Jackpot_GameProvider_IDR1000_Game_Round_Conversion_Platform_IDR()
	{
		var gameProviderCode = "AWC_PGS";
		var currencyCode = "IDR";
		var bet = 10.0m;
		var validBet = 5.0m;
		var settle = 12.5m;
		var winLoss = 7.5m;
		var turnover = 1m;
		var commission = 0.15m;
		var contribute = 0.015m;
		var jackpot = 2.5m;

		var expected = new Common.ConvertPlatformRoundsResult(
			ExchangeRate: 1000m,
			Bet: 10000m,
			ValidBet: 5000m,
			Settle: 12500m,
			WinLoss: 7500m,
			Turnover: 1000m,
			Commission: 150m,
			Contribute: 15m,
			Jackpot: 2500m);

		var web = new GameCurrencyApplicationUnitTest();

		var httpClient = web.CreateClient();

		var sut = new GameCurrencyClient(httpClient);

		var actual = await sut.ConvertPlatformRoundsAsync(
			gameProviderCode: gameProviderCode,
			currencyCode: currencyCode,
			bet: bet,
			validBet: validBet,
			settle: settle,
			winLoss: winLoss,
			turnover: turnover,
			commission: commission,
			contribute: contribute,
			jackpot: jackpot);

		Assert.NotNull(actual);
		_ = expected.Should().Be(actual);
	}
}
