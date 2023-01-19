using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingPortal_API.Data;
using OnlineShoppingPortal_API.Models;

namespace OnlineShoppingPortal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly DataContext _context;

        public SegmentController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Segments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Segment>>> GetSegments()
        {
            return await _context.Segments.ToListAsync();
        }

        // GET: api/Segments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Segment>> GetSegment(int id)
        {
            var segment = await _context.Segments.FindAsync(id);

            if (segment == null)
            {
                return NotFound();
            }

            return segment;
        }

        // PUT: api/Segments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSegment(int id, Segment segment)
        {
            if (id != segment.SegmentId)
            {
                return BadRequest();
            }

            _context.Entry(segment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Segments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Segment>> PostSegment(Segment segment)
        {
            _context.Segments.Add(segment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSegment", new { id = segment.SegmentId }, segment);
        }

        // DELETE: api/Segments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSegment(int id)
        {
            var segment = await _context.Segments.FindAsync(id);
            if (segment == null)
            {
                return NotFound();
            }

            _context.Segments.Remove(segment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SegmentExists(int id)
        {
            return _context.Segments.Any(e => e.SegmentId == id);
        }
    }
}
