namespace Tgs.GameCurrency.ViewModels
{
	public record ConvertGameProviderRoundsResult(
		decimal ExchangeRate,
		decimal BetAmount,
		decimal ValidBetAmount,
		decimal SettleAmount,
		decimal Commission,
		decimal Turnover,
		decimal WinLoss);
}
