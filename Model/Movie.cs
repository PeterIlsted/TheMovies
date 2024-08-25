using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Repository
{
    public class Movie
    {
		private int _id = -1;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		private TimeSpan _duration;

		public TimeSpan Duration
		{
			get { return _duration; }
			set { _duration = value; }
		}
		private string _genre;

		public string Genre
		{
			get { return _genre; }
			set { _genre = value; }
		}
        public Movie()
        {
            Title = "Ny Film.";
            Duration = TimeSpan.Zero;
            Genre = "Genre.";
        }
        public Movie(string Title, TimeSpan Duration, string Genre) : this()
		{
            this._title = Title;
            this._duration = Duration;
            this._genre = Genre;
        }
		public Movie(string Title, TimeSpan Duration, string Genre, int ID) : this(Title, Duration, Genre) { this._id = ID; }
	}
}
