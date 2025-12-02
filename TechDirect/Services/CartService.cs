using TechDirect.Data;

namespace TechDirect.Services
{
    public class CartService
    {
        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        private readonly List<CartItem> items = new();

        public IReadOnlyList<CartItem> Items => items;

        public void AddItem(Product product)
        {
            // Use discounted price if available, otherwise normal price
            var unitPrice = product.SellingPrice;

            var existing = items.FirstOrDefault(i => i.ProductId == product.Id);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = unitPrice,   // important: NOT product.Price
                    Quantity = 1
                });
            }

            NotifyStateChanged();
        }


        public void RemoveItem(int productId)
        {
            var item = items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                items.Remove(item);
                NotifyStateChanged();  
            }
        }

        public void Clear()
        {
            items.Clear();
            NotifyStateChanged();      
        }


        public decimal Total => items.Sum(i => i.Price * i.Quantity);


        public void IncreaseQuantity(int productId)
        {
            var item = items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity++;
                NotifyStateChanged();
            }
        }

        public void DecreaseQuantity(int productId)
        {
            var item = items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    items.Remove(item);
                }

                NotifyStateChanged();
            }
        }


    }


}
