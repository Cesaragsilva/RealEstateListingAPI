using FluentValidation;
using RealEstateListing.Domain.Entities;

namespace RealEstateListing.Application.Validators
{
    public class ListingValidator : AbstractValidator<Listing>
    {
        public ListingValidator()
        {
            RuleFor(listing => listing.Price)
                .NotNull()
                    .WithMessage("The Price is required.")
                .GreaterThan(0)
                    .WithMessage("The Price must be greater than 0.");

            RuleFor(listing => listing.Title)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required!")
                .MaximumLength(200)
                    .WithMessage("The Title cannot exceed 200 characters.");

            RuleFor(book => book.Description)
                .MaximumLength(500)
                    .When(listing=> !string.IsNullOrEmpty(listing.Description))
                        .WithMessage("The Description cannot exceed 500 characters.");
        }
    }
}
