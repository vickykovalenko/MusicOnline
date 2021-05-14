using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MeterOnline
{
	public class Style
	{
		public Style()
		{
			SongStyles = new List<SongStyles>();
		}

		public int Id { get; set; }
		public string Name { get; set; }

	}
}
