using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingPortal_API.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int CardId { get; set; }
        public CardDetail CardDetails { get; set; }

        public string PaymentType { get; set; }
        public string Amount { get; set; }
    }
}
