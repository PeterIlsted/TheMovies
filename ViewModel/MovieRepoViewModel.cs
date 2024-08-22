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
        private ObservableCollection<object> _movieRepo;
        public MovieRepoViewModel()
        {
            _movieRepo = new ObservableCollection<object>();
        }
        public ObservableCollection<object> MovieRepo { get { return _movieRepo; } }

        public object SelectedMovie { get; set; }

        public void AddMovie(object movie)
        {
            SelectedMovie = movie;
            _movieRepo.Add(movie);
            
        }


        public object EditMovie(object movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(object movie)
        {
            _movieRepo.Remove(movie);
        }

        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteMovie(SelectedMovie), CanExecute => SelectedMovie != null);
        public RelayCommand EditCommand => new RelayCommand(execute => EditMovie(SelectedMovie), canExecute => SelectedMovie != null);
        public RelayCommand NewCommand => new RelayCommand(execute => AddMovie(SelectedMovie));
    }
        
}
