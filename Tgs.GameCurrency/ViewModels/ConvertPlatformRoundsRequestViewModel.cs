using System.ComponentModel.DataAnnotations;

namespace Tgs.GameCurrency.ViewModels;

public record ConvertPlatformRoundsRequestViewModel
{
    [Required]
    public decimal Bet { get; init; }
    [Required]
    public decimal ValidBet { get; init; }
    [Required]
    public decimal Settle { get; init; }
    [Required]
    public decimal Commission { get; init; }
    [Required]
    public decimal Turnover { get; init; }
    [Required]
    public decimal WinLoss { get; init; }
}
