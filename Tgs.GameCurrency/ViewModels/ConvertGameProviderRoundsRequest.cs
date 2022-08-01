namespace Tgs.GameCurrency.ViewModels
{
	public class ConvertGameProviderRoundsRequest
	{
		public decimal? BetAmount { get; set; }

		public decimal? Commission { get; set; }

		public decimal? SettleAmount { get; set; }

		public decimal? Turnover { get; set; }

		public decimal? ValidBetAmount { get; set; }

		public decimal? WinLoss { get; set; }
	}
}
