using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MeterOnline
{
	public class SongStyles
	{
		public int Id { get; set; }
		public int SongId { get; set; }
		public int StyleId { get; set; }

		public virtual Song Song { get; set; }

		public virtual Style Style { get; set; }

	}
}
