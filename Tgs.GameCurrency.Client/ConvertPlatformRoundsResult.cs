namespace Tgs.GameCurrency.Client
{
    public record ConvertPlatformRoundsResult(
        decimal ExchangeRate,
        decimal Bet,
        decimal ValidBet,
        decimal Settle,
        decimal Commission,
        decimal Turnover,
        decimal WinLoss);
}
