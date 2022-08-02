namespace Tgs.GameCurrency.Client
{
	public record ConvertPlatformRoundsResult(
		decimal ExchangeRate,
		decimal BetAmount,
		decimal ValidBetAmount,
		decimal SettleAmount,
		decimal Commission,
		decimal Turnover,
		decimal WinLoss);
}
