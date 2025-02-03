namespace RealEstateListing.Domain.Entities
{
    public class Listing : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }  // Decimal is a value type and non-nullable by default
        public string? Description { get; set; }  // Mark as nullable if appropriate
    }
}