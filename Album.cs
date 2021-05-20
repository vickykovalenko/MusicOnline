using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MusicOnline
{
	public class Album
	{
		public Album()
		{
			Songs = new List<Song>();
		}
		public int Id { get; set; }
		public string Name { get; set; }

		public string ReleaseYear { get; set; }

		public string Genre { get; set; }

		public virtual ICollection<Song> Songs { get; set; }
	}
}
