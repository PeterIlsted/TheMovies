using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Repository;
using TheMovies.MVVM;

namespace TheMovies.ViewModel
{
    public interface DialogVisitor
    {
        Movie DynamicVisit(Movie data);
    }
    public class MovieRepoViewModel : ViewModelBase
    {
        private readonly IMovieRepository repository;
        public ObservableCollection<Movie> MovieRepo { get; set; }
        //public MovieRepoViewModel() { MovieRepo = new ObservableCollection<Movie>(); }
        public MovieRepoViewModel(DialogVisitor visitor, IMovieRepository Repository) 
        { 
            Visitor = visitor;
            repository = Repository;
            MovieRepo = new ObservableCollection<Movie>(repository.GetAllMovies());
        }
        public DialogVisitor Visitor { get; set; }
        
        private Movie _selectedItem;
        public Movie SelectedMovie 
        {
            get {  return _selectedItem; } 
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
            
        }

        public void DeleteMovie()
        {
            repository.DeleteMovie(SelectedMovie.Id);
            MovieRepo.Remove(SelectedMovie);
        }

        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteMovie(), CanExecute => SelectedMovie != null);
        public RelayCommand EditCommand => new RelayCommand(execute => EditMovie(SelectedMovie), canExecute => SelectedMovie != null);
        public RelayCommand NewCommand => new RelayCommand(execute => AddMovie());
    }
        
}
