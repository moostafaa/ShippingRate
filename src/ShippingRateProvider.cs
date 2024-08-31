using ShippinRate.Models;
using ShippinRate.Providers;
using ShippinRate.Infrastructure;

namespace ShippinRate
{
    public class ShippingRateProvider
    {
        public async Task<decimal> GetCheapestRateAsync(ShippingQuote shippingQuote)
        {
            var tasks = new List<Task<decimal>>();
            foreach (var shippingProvider in ShippingProviderFactory.GetShippingProviders())
                tasks.Add(shippingProvider.GetRateAsync(shippingQuote));
            decimal cheapestRate = decimal.MaxValue;
            await foreach (var result in LinqExtensions.WhenEach(tasks))
            {
                if(result < cheapestRate)
                    cheapestRate = result;
            }
            return cheapestRate;
        }
    }
}
