using FastEndpoints;
using ShippinRate.Models;

namespace ShippinRate
{
    public class ShippingEndpoint : Endpoint<ShippingQuote, decimal>
    {
        public ShippingRateProvider Provider { get; set; }
        public override void Configure()
        {
            Post("api/v1/shipping");
            Policies("Managers");
        }

        public override async Task HandleAsync(ShippingQuote req, CancellationToken ct)
        {
            var result = await Provider.GetCheapestRateAsync(req);
            await SendAsync(result, cancellation: ct);
        }
    }
}
