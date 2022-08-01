namespace Tgs.GameCurrency.Client
{
	public record ConvertPlatformRoundsRequest(
		decimal BetAmount,
		decimal Commission,
		decimal SettleAmount,
		decimal Turnover,
		decimal ValidBetAmount,
		decimal WinLoss);
}
