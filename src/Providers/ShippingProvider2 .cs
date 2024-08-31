using ShippinRate.Models;
using System.Text.Json;

namespace ShippinRate.Providers
{
    public class ShippingProvider2 : IShippingProvider
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<decimal> GetRateAsync(ShippingQuote quote)
        {
            var requestBody = new
            {
                consignee = quote.DestinationAddress,
                consignor = quote.SourceAddress,
                cartons = quote.Dimensions
            };

            HttpResponseMessage response = await client.PostAsJsonAsync("https://api.provider2.com/getquote", requestBody);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<ShippingProviderResult>(jsonResponse);
            return json.total_amount;
        }

        private class ShippingProviderResult
        {
            public decimal total_amount { get; set; }
        }
    }
}
