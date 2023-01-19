using System.ComponentModel;

namespace OnlineShoppingPortal_API.Models
{
    public class User
    {
        public int UserId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string UserName { set; get; }
        public string EmailId { set; get; }
        public string Password { set; get; }
        public string Token { set; get; }
        public string Role{ set; get; }
        public Customer Customer { get; set; }

    }
}
