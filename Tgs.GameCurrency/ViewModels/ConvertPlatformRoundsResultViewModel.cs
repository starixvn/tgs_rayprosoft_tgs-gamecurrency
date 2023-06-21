namespace Tgs.GameCurrency.ViewModels;

public record ConvertPlatformRoundsResultViewModel(
    decimal ExchangeRate,
    decimal Bet,
    decimal ValidBet,
    decimal Settle,
    decimal Commission,
    decimal Turnover,
    decimal WinLoss);
