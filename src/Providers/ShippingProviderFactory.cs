namespace ShippinRate.Providers;

public static class ShippingProviderFactory
{
    public static IEnumerable<IShippingProvider> GetShippingProviders()
    {
        return
        [
            new ShippingProvider1(),
            new ShippingProvider2(),
            new ShippingProvider3()
        ];
    }
}
