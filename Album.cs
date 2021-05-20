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
		[Required(ErrorMessage = "Поле не повинно бути порожнім")]
		[Display(Name = "Назва")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Поле не повинно бути порожнім")]
		[Display(Name = "Рік випуску")]
		public string ReleaseYear { get; set; }


		public virtual ICollection<Song> Songs { get; set; }
	}
}
