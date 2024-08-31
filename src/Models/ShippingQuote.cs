namespace ShippinRate.Models;

public class ShippingQuote
{
    public required string SourceAddress { get; set; }
    public required string DestinationAddress { get; set; }
    public required List<ParcelDimension> Dimensions { get; set; }
}
