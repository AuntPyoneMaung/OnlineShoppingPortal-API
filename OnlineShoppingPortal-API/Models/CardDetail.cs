using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingPortal_API.Models
{
    public class CardDetail
    {
        [Key]
        public int CardId { get; set; }
        public int CardNo { get; set; }
        public string CardholderName { get; set; }
        public string ExpiryDate { get; set; }
        public string Bank { get; set; }
        public string CardType { get; set; }

    }
}
