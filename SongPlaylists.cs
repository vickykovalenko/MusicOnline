using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MusicOnline
{
	public class SongPlaylists
	{
		public int Id { get; set; }
		public int PlaylistId { get; set; }

		public int SongId { get; set; }

		public virtual Song Song { get; set; }

		public virtual Playlist Playlist { get; set; }
	}
}
