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
    public class ArtistSongsController : ControllerBase
    {
        private readonly MusicContext _context;

        public ArtistSongsController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/ArtistSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistSongs>>> GetArtistSongs()
        {
            return await _context.ArtistSongs.ToListAsync();
        }

        // GET: api/ArtistSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistSongs>> GetArtistSongs(int id)
        {
            var artistSongs = await _context.ArtistSongs.FindAsync(id);

            if (artistSongs == null)
            {
                return NotFound();
            }

            return artistSongs;
        }

        // PUT: api/ArtistSongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtistSongs(int id, ArtistSongs artistSongs)
        {
            if (id != artistSongs.Id)
            {
                return BadRequest();
            }

            _context.Entry(artistSongs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistSongsExists(id))
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

        // POST: api/ArtistSongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtistSongs>> PostArtistSongs(ArtistSongs artistSongs)
        {
            _context.ArtistSongs.Add(artistSongs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtistSongs", new { id = artistSongs.Id }, artistSongs);
        }

        // DELETE: api/ArtistSongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtistSongs(int id)
        {
            var artistSongs = await _context.ArtistSongs.FindAsync(id);
            if (artistSongs == null)
            {
                return NotFound();
            }

            _context.ArtistSongs.Remove(artistSongs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistSongsExists(int id)
        {
            return _context.ArtistSongs.Any(e => e.Id == id);
        }
    }
}
