namespace TechDirect.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }
 
        public decimal? DiscountPrice { get; set; }

        public int Stock { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
        public bool IsOnDeal =>
            DiscountPrice.HasValue &&
            DiscountPrice.Value > 0 &&
            DiscountPrice.Value < Price;

        public decimal SellingPrice =>
            IsOnDeal ? DiscountPrice!.Value : Price;
    }
}
