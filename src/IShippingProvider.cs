using ShippinRate.Models;

public interface IShippingProvider
{
    Task<decimal> GetRateAsync(ShippingQuote shippingQuote);
}
