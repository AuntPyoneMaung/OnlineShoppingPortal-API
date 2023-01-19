using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingPortal_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        //public int BrandId { get; set; }
        //public Brand Brand { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductModel { get; set; }
        public int ProductPrice { get; set; }

        public ICollection<BrandProduct> BrandProducts { get; set; }
        //public ICollection<Brand> Brands { get; set; }

    }
}
