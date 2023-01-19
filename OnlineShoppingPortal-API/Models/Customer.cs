using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingPortal_API.Models
{
    public class Customer
    {
        [Key]
        public int CustId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }    
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string? City { set; get; }
        public string? State { set; get; }
        public string? ZIP { set; get; }
        public string? Phone { set; get; }
        public string EmailId { set; get; }
        public int UserId { set; get; }
        public User User { get; set; }
        public string Password { set; get; }
    }
}
