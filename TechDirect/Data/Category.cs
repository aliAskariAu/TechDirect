namespace TechDirect.Data
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // Navigation property to products in this category
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
