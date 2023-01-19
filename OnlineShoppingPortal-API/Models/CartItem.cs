using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingPortal_API.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public int TotalCost { get; set; }

        // posts
    }
}

