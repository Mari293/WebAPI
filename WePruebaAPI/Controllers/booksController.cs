using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPruebaAPI.Data;
using WebPruebaAPI.Models;

namespace WebPruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        private readonly WebPruebaAPIContext _context;

        public booksController(WebPruebaAPIContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<books>>> Getbooks()
        {
            return await _context.books.ToListAsync();
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<books>> Getbooks(int id)
        {
            var books = await _context.books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        // PUT: api/books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbooks(int id, books books)
        {
            if (id != books.id)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!booksExists(id))
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

        // POST: api/books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<books>> Postbooks(books books)
        {
            _context.books.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbooks", new { id = books.id }, books);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<books>> Deletebooks(int id)
        {
            var books = await _context.books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.books.Remove(books);
            await _context.SaveChangesAsync();

            return books;
        }

        private bool booksExists(int id)
        {
            return _context.books.Any(e => e.id == id);
        }
    }
}
