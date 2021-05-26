using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicOnline;

namespace MusicOnline.Models
{
	public class Style
	{
		public Style()
		{
			SongStyles = new List<SongStyles>();
		}

		public int Id { get; set; }
		[Required(ErrorMessage = "Поле не повинно бути порожнім")]
		[Display(Name = "Назва")]
		public string Name { get; set; }

		public virtual ICollection<SongStyles> SongStyles { get; set; }

	}
}
