namespace Tgs.GameCurrency.Common;
public record ConvertPlatformRoundsResult(
	decimal ExchangeRate,
	decimal Bet,
	decimal ValidBet,
	decimal Settle,
	decimal WinLoss,
	decimal Turnover,
	decimal Commission,
	decimal Contribute,
	decimal Jackpot);
