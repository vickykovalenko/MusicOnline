using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MusicOnline
{
	public class Playlist
	{
		public Playlist()
		{
			SongPlaylists = new List<SongPlaylists>();
		}
		public int Id { get; set; }


		public string Name { get; set; }

		public virtual ICollection<SongPlaylists> SongPlaylists { get; set; }
	}
}