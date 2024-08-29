using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TheMovies.Model;


namespace TheMovies.Repository
{
    internal class MovieRepository : IMovieRepository
    {
        private List<Movie> _movieRepo = new List<Movie>();
        private DataHandler dataHandler = new DataHandler();
        public MovieRepository()
        {
            AddRepo();
        }
        public void AddRepo()
        {
            List<Movie> movies = dataHandler.GetMovies();
            foreach (Movie movie in movies) { AddMovie(movie); }
        }
        public void AddMovie(Movie movie)
        {
            if (_movieRepo.Count == 0)
            {
                movie.Id = 1;
                _movieRepo.Add(movie);
                
            }
            else
            {
                movie.Id = _movieRepo.Max(m => m.Id) + 1;
                _movieRepo.Add(movie);
            }
            
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
