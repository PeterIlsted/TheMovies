using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheMovies.Repository
{
    internal class MovieRepository : IMovieRepository
    {
        private List<Movie> _movieRepo = new List<Movie>();
        public MovieRepository() 
        {
            _movieRepo.Add(new Movie("MLP - Horror at Ponyvile", new TimeSpan(01, 45, 00), "Familiefilm", 1));
            _movieRepo.Add(new Movie("Rouladens historie gennem tiderne", new TimeSpan(2, 35, 00), "Systemkritisk Naturalistisk Dokumentar", 2));
        }
        public void AddMovie(Movie movie)
        {
            movie.Id = _movieRepo.Max(m => m.Id) + 1;
            _movieRepo.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            var movie = GetMovieById(id);
            if(movie != null) { _movieRepo.Remove(movie); }
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieRepo;
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepo.FirstOrDefault(m => m.Id == id);
        }

        public void UpdateMovie(Movie movie)
        {
            Movie Existingmovie = GetMovieById(movie.Id);
            if(Existingmovie != null)
            {
                Existingmovie.Title = movie.Title;
                Existingmovie.Duration = movie.Duration;
                Existingmovie.Genre = movie.Genre;
            }
        }
    }
}
