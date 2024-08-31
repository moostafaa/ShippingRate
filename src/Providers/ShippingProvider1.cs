using ShippinRate.Models;
using System.Text.Json;

namespace ShippinRate.Providers
{
    public class ShippingProvider1 : IShippingProvider
    {
        private static readonly HttpClient client = new();
        public async Task<decimal> GetRateAsync(ShippingQuote quote)
        {
            var requestBody = new
            {
                contact_address = quote.SourceAddress,
                warehouse_address = quote.DestinationAddress,
                package_dimensions = quote.Dimensions
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("https://api.provider1.com/getquote", requestBody);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<ShippingProviderResult>(jsonResponse);
            return json.total_amount;
        }

        private class ShippingProviderResult
        {
            public decimal total_amount;
        }
    }
}
