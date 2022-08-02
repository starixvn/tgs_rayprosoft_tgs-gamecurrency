namespace Tgs.GameCurrency.ViewModels
{
	public record ConvertPlatformRoundsResultViewModel(
		decimal ExchangeRate,
		decimal BetAmount,
		decimal ValidBetAmount,
		decimal SettleAmount,
		decimal Commission,
		decimal Turnover,
		decimal WinLoss);
}
