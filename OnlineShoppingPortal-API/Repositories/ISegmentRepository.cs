using OnlineShoppingPortal_API.Models;

namespace OnlineShoppingPortal_API.Repositories
{
    public interface ISegmentRepository
    {
        Task<IEnumerable<Segment>> GetSegments();
    }
}