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
    public class SongPlaylistsController : ControllerBase
    {
        private readonly MusicContext _context;

        public SongPlaylistsController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/SongPlaylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongPlaylists>>> GetSongPlaylists()
        {
            return await _context.SongPlaylists.ToListAsync();
        }

        // GET: api/SongPlaylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongPlaylists>> GetSongPlaylists(int id)
        {
            var songPlaylists = await _context.SongPlaylists.FindAsync(id);

            if (songPlaylists == null)
            {
                return NotFound();
            }

            return songPlaylists;
        }

        // PUT: api/SongPlaylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongPlaylists(int id, SongPlaylists songPlaylists)
        {
            if (id != songPlaylists.Id)
            {
                return BadRequest();
            }

            _context.Entry(songPlaylists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongPlaylistsExists(id))
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

        // POST: api/SongPlaylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongPlaylists>> PostSongPlaylists(SongPlaylists songPlaylists)
        {
            _context.SongPlaylists.Add(songPlaylists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongPlaylists", new { id = songPlaylists.Id }, songPlaylists);
        }

        // DELETE: api/SongPlaylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongPlaylists(int id)
        {
            var songPlaylists = await _context.SongPlaylists.FindAsync(id);
            if (songPlaylists == null)
            {
                return NotFound();
            }

            _context.SongPlaylists.Remove(songPlaylists);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongPlaylistsExists(int id)
        {
            return _context.SongPlaylists.Any(e => e.Id == id);
        }
    }
}
