using Shop11A.Models;

public class Cart
{
    public List<CartItem> Items { get; set; }

    public Cart()
    {
        Items = new List<CartItem>();
    }

    // Add item to cart
    public void AddItem(Product product)
    {
        var cartItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
        if (cartItem == null)
        {
            Items.Add(new CartItem
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1
            });
        }
        else
        {
            cartItem.Quantity++;
        }
    }

    // Remove item from cart
    public void RemoveItem(int productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

    // Get total price of cart
    public decimal GetTotalPrice()
    {
        return Items.Sum(i => i.Price * i.Quantity);
    }
}
