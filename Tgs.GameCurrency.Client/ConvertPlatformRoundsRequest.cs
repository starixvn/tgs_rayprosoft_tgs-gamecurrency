namespace Tgs.GameCurrency.Client
{
	public record ConvertPlatformRoundsRequest(
		decimal BetAmount,
		decimal ValidBetAmount,
		decimal SettleAmount,
		decimal Commission,
		decimal Turnover,
		decimal WinLoss);
}
