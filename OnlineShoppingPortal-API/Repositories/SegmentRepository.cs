using OnlineShoppingPortal_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using OnlineShoppingPortal_API.Models;

namespace OnlineShoppingPortal_API.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        private readonly DataContext dataContext;

        public SegmentRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public async Task<IEnumerable<Segment>> GetSegments()
        {
            return await dataContext.Segments.ToListAsync();
        }

        public async Task<Segment> GetSegment(int segmentId)
        {
            return await dataContext.Segments.FirstOrDefaultAsync(e => e.SegmentId == segmentId);
        }

        public async Task<Segment> AddSegment(Segment segment)
        {
            var result = await dataContext.Segments.AddAsync(segment);
            await dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Segment> DeleteSegment(int segmentId)
        {
            var result = await dataContext.Segments.FirstOrDefaultAsync(s => s.SegmentId == segmentId);
            if (result != null)
            {
                dataContext.Segments.Remove(result);
                await dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
