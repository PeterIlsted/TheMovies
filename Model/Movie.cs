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
			private set { title = value; }
		}
		private TimeSpan duration;

		public TimeSpan Duration
		{
			get { return duration; }
			private set { duration = value; }
		}
		private string genre;

		public string Genre
		{
			get { return genre; }
			private set { genre = value; }
		}
		public Movie(string Title, TimeSpan Duration, string Genre)
		{
			this.title = Title;
			this.duration = Duration;
			this.genre = Genre;
		}
		public Movie() : this("Ny Film", TimeSpan.Zero, "Genre") { }
		public string GetMovie() { return @"{Title}, {Duration}, {Genre}"; }
	}
}
