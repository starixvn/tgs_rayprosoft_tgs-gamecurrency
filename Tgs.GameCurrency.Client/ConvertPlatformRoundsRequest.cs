namespace Tgs.GameCurrency.Client
{
	public record ConvertPlatformRoundsRequest(
		decimal Bet,
		decimal ValidBet,
		decimal Settle,
		decimal Commission,
		decimal Turnover,
		decimal WinLoss);
}
