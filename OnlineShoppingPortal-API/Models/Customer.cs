using System.ComponentModel;

namespace OnlineShoppingPortal_API.Models
{
    public class Customer
    {
        public int CustomerId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string UserName { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string? City { set; get; }
        public string? State { set; get; }
        public string? ZIP { set; get; }
        public string? Phone { set; get; }
        public string EmailId { set; get; }
        public string Password { set; get; }
        public string Token { set; get; }
        public string Role{ set; get; }

    }
}
