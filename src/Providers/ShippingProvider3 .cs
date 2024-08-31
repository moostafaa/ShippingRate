using ShippinRate.Models;
using System.Xml.Linq;

namespace ShippinRate.Providers;

public class ShippingProvider3 : IShippingProvider
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<decimal> GetRateAsync(ShippingQuote quote)
    {
        var requestBody = new XElement("request",
            new XElement("source", quote.SourceAddress),
            new XElement("destination", quote.DestinationAddress),
            new XElement("packages",
                new XElement("package", new XElement("dimensions",
                    string.Join(", ", quote.Dimensions.ConvertAll(d => $"{d.Width}x{d.Height}x{d.Length}"))))
            )
        );

        var content = new StringContent(requestBody.ToString(), System.Text.Encoding.UTF8, "application/xml");
        HttpResponseMessage response = await client.PostAsync("https://api.provider3.com/getquote", content);
        response.EnsureSuccessStatusCode();

        var xmlResponse = await response.Content.ReadAsStringAsync();
        var xmlDoc = XDocument.Parse(xmlResponse);
        return decimal.Parse(xmlDoc.Root.Element("quote")?.Value);
    }
}
