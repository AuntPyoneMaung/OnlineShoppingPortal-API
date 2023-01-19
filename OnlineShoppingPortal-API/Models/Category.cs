using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingPortal_API.Models
{
    // integrity depends on valid refernece to Segment (1-M)
    // Segment becomes the principal entity 
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        //[ForeignKey("Segment")] 
        //annotation is to override default, key conventions
        public int SegmentId { get; set; }
        public Segment Segment { get; set; }

        public string CategoryName { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}
