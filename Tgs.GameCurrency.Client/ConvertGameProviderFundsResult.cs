namespace Tgs.GameCurrency.Client;

public record ConvertGameProviderFundsResult(
    decimal ExchangeRate,
    decimal Amount);
