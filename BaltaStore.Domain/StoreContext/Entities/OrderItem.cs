using System.Collections.Generic;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {

        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            if (product.QuantityOnHand < quantity)
            {
                AddNotification("Quantity", "Produto fora de estoque");
            }

            product.DecreaseQuantity(quantity);
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}