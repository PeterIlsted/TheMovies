using System.Collections.ObjectModel;
using System.Windows.Input;
using TheMovies.Repository;
using TheMovies.MVVM;
using TheMovies.Model;
using System;
using TheMovies.View;

namespace TheMovies.ViewModel
{
    public interface IDialogVisitor
    {
        Movie DynamicVisit(Movie data);
    }
    public class MovieRepoViewModel : ViewModelBase
    {
        private readonly IMovieRepository repository;
        public ObservableCollection<Movie> MovieRepo { get; set; }
        public IDialogVisitor Visitor { get; set; }

        // Konstruktør
        public MovieRepoViewModel(IDialogVisitor visitor, IMovieRepository Repository)
        {
            Visitor = visitor;
            repository = Repository;
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