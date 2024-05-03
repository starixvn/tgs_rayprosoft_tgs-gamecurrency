namespace Tgs.GameCurrency.ViewModels;

public record ConvertPlatformRoundsRequestViewModel
{
	public decimal Bet { get; init; } = 0.0m;
	public decimal ValidBet { get; init; } = 0.0m;
	public decimal Settle { get; init; } = 0.0m;
	public decimal Commission { get; init; } = 0.0m;
	public decimal Turnover { get; init; } = 0.0m;
	public decimal WinLoss { get; init; } = 0.0m;
	public decimal Jackpot { get; init; } = 0.0m;
}
