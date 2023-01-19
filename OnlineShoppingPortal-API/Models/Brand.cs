using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingPortal_API.Models
{
    // a
    public class Brand
    {
        public int BrandId { get; set; }

        // navigation property : a property defined on the principal and/or dependent entity that references the realted entity
        // foreign key property recommended but not required - shadow FK introduced
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string BrandName { get; set; }

        public ICollection<BrandProduct> BrandProducts { get; set; }
        //public ICollection<Product> Products{ get; set; }

    }
}
