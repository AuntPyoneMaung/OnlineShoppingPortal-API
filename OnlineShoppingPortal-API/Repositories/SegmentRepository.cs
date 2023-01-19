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

    }
}
