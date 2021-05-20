using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MusicOnline
{
	public class Song
	{
		public Song()
		{
			SongStyles = new List<SongStyles>();
			ArtistSongs = new List<ArtistSongs>();
			SongPlaylists = new List<SongPlaylists>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public int AlbumId { get; set; }

		public virtual Album Album { get; set; }
		public virtual ICollection <SongStyles> SongStyles { get; set; }

		public virtual ICollection <ArtistSongs> ArtistSongs { get; set; }

		public virtual ICollection <SongPlaylists> SongPlaylists { get; set; }
			 

	}
}
