namespace RealEstateListing.Domain.Entities
{
    public class Listing : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string? Description { get; set; }  // Mark as nullable if appropriate
    }
}