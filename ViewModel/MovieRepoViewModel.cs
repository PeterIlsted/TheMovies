using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;
using TheMovies.MVVM;

namespace TheMovies.ViewModel
{
    public class MovieRepoViewModel : ViewModelBase
    {
        private ObservableCollection<Movie> _movieRepo;
        public MovieRepoViewModel()
        {
            _movieRepo = new ObservableCollection<Movie>();
        }
        public ObservableCollection<Movie> MovieRepo { get { return _movieRepo; } }
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

        public void AddMovie(Movie movie)
        {
            SelectedMovie = movie;
            _movieRepo.Add(movie);
            
        }


        public Movie EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie movie)
        {
            _movieRepo.Remove(movie);
        }

        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteMovie(SelectedMovie), CanExecute => SelectedMovie != null);
        public RelayCommand EditCommand => new RelayCommand(execute => EditMovie(SelectedMovie), canExecute => SelectedMovie != null);
        public RelayCommand NewCommand => new RelayCommand(execute => AddMovie(SelectedMovie));
    }
        
}
