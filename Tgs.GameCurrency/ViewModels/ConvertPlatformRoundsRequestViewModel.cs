namespace Tgs.GameCurrency.ViewModels
{
	public record ConvertPlatformRoundsRequestViewModel
	{
		public decimal BetAmount { get; init; }
		public decimal ValidBetAmount { get; init; }
		public decimal SettleAmount { get; init; }
		public decimal Commission { get; init; }
		public decimal Turnover { get; init; }
		public decimal WinLoss { get; init; }
	}
}
