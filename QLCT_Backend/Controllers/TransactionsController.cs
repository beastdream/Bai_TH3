using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCT_Backend.Data;
using QLCT_Backend.Models;

namespace QLCT_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions?identifier=user@gmail.com
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(string? identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return Ok(new List<Transaction>());
            return await _context.Transactions
                .Where(t => t.UserEmail == identifier)
                .ToListAsync();
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Ok(transaction);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(long id, Transaction transaction)
        {
            if (id != transaction.Id) return BadRequest();
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(long id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return NotFound();
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}