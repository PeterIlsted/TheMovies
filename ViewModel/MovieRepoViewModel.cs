using System.Collections.ObjectModel;
using System.Windows.Input;
using TheMovies.Repository;
using TheMovies.MVVM;
using TheMovies.Model;
using System;
using TheMovies.View;

namespace TheMovies.ViewModel
{
    public class MovieRepoViewModel : ViewModelBase
    {
        private readonly IMovieRepository repository;
        private DataHandler dataHandler;
        public ObservableCollection<Movie> MovieRepo { get; set; }
        public IDialogVisitor Visitor { get; set; }

        // Konstruktør
        public MovieRepoViewModel(IDialogVisitor visitor, IMovieRepository repository, DataHandler dataHandler)
        {
            this.dataHandler = dataHandler ?? throw new ArgumentNullException(nameof(dataHandler));
            Visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            MovieRepo = new ObservableCollection<Movie>(repository.GetAllMovies());
        }

        private Movie _selectedItem;
        public Movie SelectedMovie
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public DataHandler DataHandler
        {
            get { return dataHandler; }
            set
            {
                if (dataHandler != value)
                {
                    dataHandler = value;
                    OnPropertyChanged();
                }
            }
        }

        // Kommando til at åbne CSV filen
        public ICommand OpenFileCommand => new RelayCommand(execute => OpenFile());

        private void OpenFile()
        {
            if (dataHandler == null)
                throw new InvalidOperationException("DataHandler is not set.");

            var movies = dataHandler.LoadMovies();
            MovieRepo.Clear();
            foreach (var movie in movies)
            {
                MovieRepo.Add(movie);
            }
        }

        public void AddMovie()
        {
            if (Visitor == null) throw new InvalidOperationException("Visitor is not set.");
            Movie movie = new Movie();
            Visitor.DynamicVisit(movie);
            MovieRepo.Add(movie);
            repository.AddMovie(movie);
        }

        public void EditMovie(Movie movie)
        {
            if (Visitor == null) throw new InvalidOperationException("Visitor is not set.");
            if (SelectedMovie == null) throw new InvalidOperationException("SelectedMovie is not set.");

            Visitor.DynamicVisit(movie);
            MovieRepo[MovieRepo.IndexOf(SelectedMovie)] = movie;
            repository.UpdateMovie(movie);
        }

        public void DeleteMovie()
        {
            if (SelectedMovie == null) return;
            repository.DeleteMovie(SelectedMovie.Id);
            MovieRepo.Remove(SelectedMovie);
        }

        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteMovie(), canExecute => SelectedMovie != null);
        public RelayCommand EditCommand => new RelayCommand(execute => EditMovie(SelectedMovie), canExecute => SelectedMovie != null);
        public RelayCommand NewCommand => new RelayCommand(execute => AddMovie());
    }
}