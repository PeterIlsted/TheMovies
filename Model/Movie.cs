using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Movie
    {
		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		private TimeSpan duration;

		public TimeSpan Duration
		{
			get { return duration; }
			set { duration = value; }
		}
		private string genre;

		public string Genre
		{
			get { return genre; }
			set { genre = value; }
		}
		public Movie(string Title, TimeSpan Duration, string Genre)
		{
			this.title = Title;
			this.duration = Duration;
			this.genre = Genre;
		}
		public Movie() : this("Ny Film", TimeSpan.Zero, "Genre") { }
	}
}
