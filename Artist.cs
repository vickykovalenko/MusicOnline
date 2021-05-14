using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MusicOnline
{
	public class Artist
	{
		public Artist()
		{
			ArtistSongs = new List <ArtistSongs>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection <ArtistSongs> ArtistSongs { get; set; }
	}
}