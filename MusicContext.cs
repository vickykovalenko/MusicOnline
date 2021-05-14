﻿using System;
using Microsoft.EntityFrameworkCore;


namespace MusicOnline
{
	public class MusicContext : DbContext
	{
		public virtual DbSet<Artist> Artists { get; set; }

		public virtual DbSet<ArtistSongs> ArtistSongs { get; set; }

		public virtual DbSet<Playlist> Playlists { get; set; }

		public virtual DbSet<Song> Songs { get; set; }

		public virtual DbSet<SongPlaylists> SongPlaylists { get; set; }

		public virtual DbSet<SongStyles> SongStyles { get; set; }
		public virtual DbSet<Style> Styles { get; set; }

		public MusicContext(DbContextOptions<MusicContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}










