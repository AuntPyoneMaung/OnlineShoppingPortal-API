using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingPortal_API.Models
{
    public class Segment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SegmentId { get; set; }
        public string SegmentName { get; set; }
        //public ICollection<Category> Categories { get; set; }

        /** examples:
         * organic
         * halal
         * finger foods
         * vegetarian
        **/
    }
}
