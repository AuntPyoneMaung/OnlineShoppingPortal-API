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
    public class CardDetailController : ControllerBase
    {
        private readonly DataContext _context;

        public CardDetailController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CardDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDetail>>> GetCardDetails()
        {
            return await _context.CardDetails.ToListAsync();
        }

        // GET: api/CardDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDetail>> GetCardDetail(int id)
        {
            var cardDetail = await _context.CardDetails.FindAsync(id);

            if (cardDetail == null)
            {
                return NotFound();
            }

            return cardDetail;
        }

        // PUT: api/CardDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardDetail(int id, CardDetail cardDetail)
        {
            if (id != cardDetail.CardId)
            {
                return BadRequest();
            }

            _context.Entry(cardDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardDetailExists(id))
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

        // POST: api/CardDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardDetail>> PostCardDetail(CardDetail cardDetail)
        {
            _context.CardDetails.Add(cardDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardDetail", new { id = cardDetail.CardId }, cardDetail);
        }

        // DELETE: api/CardDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardDetail(int id)
        {
            var cardDetail = await _context.CardDetails.FindAsync(id);
            if (cardDetail == null)
            {
                return NotFound();
            }

            _context.CardDetails.Remove(cardDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardDetailExists(int id)
        {
            return _context.CardDetails.Any(e => e.CardId == id);
        }
    }
}
