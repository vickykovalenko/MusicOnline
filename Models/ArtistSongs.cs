using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;


namespace MusicOnline.Models
{
	public class ArtistSongs
	{
		public int Id { get; set; }

		public int ArtistId { get; set; }

		public int SongId { get; set; }

		public virtual Artist Artist { get; set; }

		public virtual Song Song { get; set; }
	}
}
