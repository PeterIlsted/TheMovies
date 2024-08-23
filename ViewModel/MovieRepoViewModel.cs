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
        public ObservableCollection<Movie> MovieRepo { get; set; }
        public MovieRepoViewModel()
        {
            MovieRepo = new ObservableCollection<Movie>();
        }
        
        private Movie _selectedItem;
        private int _selectedIndex;
        public int SelectedIndex 
        { 
            get { return _selectedIndex; } 
            set 
            { 
                _selectedIndex = MovieRepo.IndexOf(SelectedMovie);
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

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
            MovieRepo.Add(movie);
            
        }


        public Movie EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie()
        {
            MovieRepo.Remove(SelectedMovie);
        }

        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteMovie(), CanExecute => SelectedMovie != null);
        public RelayCommand EditCommand => new RelayCommand(execute => EditMovie(SelectedMovie), canExecute => SelectedMovie != null);
        public RelayCommand NewCommand => new RelayCommand(execute => AddMovie(SelectedMovie));
    }
        
}
