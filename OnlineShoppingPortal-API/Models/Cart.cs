using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingPortal_API.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public Customer Customer { get; set; }

        public float TotalCost { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
    // blog
}
