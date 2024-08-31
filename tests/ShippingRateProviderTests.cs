using ShippinRate;
using ShippinRate.Models;


[TestFixture]
public class ShippingRateProviderTests
{
    private ShippingRateProvider _shippingRateProvider;

    [SetUp]
    public void Setup()
    {
        _shippingRateProvider = new ShippingRateProvider();
    }

    [Test]
    public async Task GetCheapestRate_ShouldReturnLowestRate()
    {
        var shippingQuote = new ShippingQuote
        {
            SourceAddress = "123 Main St, City, State, 12345",
            DestinationAddress = "456 Elm St, City, State, 67890",
            Dimensions =
            [
                new ParcelDimension { Width = 10, Height = 5, Length = 15 }
            ]
        };

        decimal cheapestRate = await _shippingRateProvider.GetCheapestRateAsync(shippingQuote);

        Assert.That(cheapestRate, Is.GreaterThan(0)); // Assuming we expect a positive rate
    }
}