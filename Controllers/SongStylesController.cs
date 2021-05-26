using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicOnline.Models;

namespace MusicOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongStylesController : ControllerBase
    {
        private readonly MusicContext _context;

        public SongStylesController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/SongStyles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongStyles>>> GetSongStyles()
        {
            return await _context.SongStyles.ToListAsync();
        }

        // GET: api/SongStyles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongStyles>> GetSongStyles(int id)
        {
            var songStyles = await _context.SongStyles.FindAsync(id);

            if (songStyles == null)
            {
                return NotFound();
            }

            return songStyles;
        }

        // PUT: api/SongStyles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongStyles(int id, SongStyles songStyles)
        {
            if (id != songStyles.Id)
            {
                return BadRequest();
            }

            _context.Entry(songStyles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongStylesExists(id))
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

        // POST: api/SongStyles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongStyles>> PostSongStyles(SongStyles songStyles)
        {
            _context.SongStyles.Add(songStyles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongStyles", new { id = songStyles.Id }, songStyles);
        }

        // DELETE: api/SongStyles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongStyles(int id)
        {
            var songStyles = await _context.SongStyles.FindAsync(id);
            if (songStyles == null)
            {
                return NotFound();
            }

            _context.SongStyles.Remove(songStyles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongStylesExists(int id)
        {
            return _context.SongStyles.Any(e => e.Id == id);
        }
    }
}
