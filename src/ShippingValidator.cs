using FastEndpoints;
using FluentValidation;
using ShippinRate.Models;

namespace ShippinRate;

public class ShippingValidator : Validator<ShippingQuote>
{
    public ShippingValidator()
    {
        RuleFor(x => x.Dimensions)
            .NotEmpty()
            .WithMessage("Enter parcel information");
    }
}
