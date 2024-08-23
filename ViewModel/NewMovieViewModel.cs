using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;
using TheMovies.MVVM;

namespace TheMovies.ViewModel
{
    public class NewMovieViewModel : ViewModelBase
    {
        public NewMovieViewModel()
        {
        }
        public NewMovieViewModel(Movie selectedMovie)
        {
            movie = selectedMovie;
        }
        Movie movie;
        private string _title = "Ny Film.";
        
        public string Title 
        {
            get { return _title; } 
            set 
            {  
                _title = value;
                OnPropertyChanged();
            } 
            
        }
        private TimeSpan _duration;
        public TimeSpan Duration 
        { 
            get { return _duration; }
            set 
            { 
                _duration = TimeSpan.Parse(value.ToString(@"hh\:mm")); 
                OnPropertyChanged();
            }
        }
        private string _genre;
        public string Genre 
        {
            get { return _genre; } 
            set 
            { 
                _genre = value; 
                OnPropertyChanged();
            }
        }
        private bool filled()
        {
            if (Title != "Ny Film." && Duration != TimeSpan.Zero && Genre != null) { return true; }
            else return false;
        }

        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => filled() == true);
        public Movie Save() 
        {
            movie = new Movie(Title, Duration, Genre);
            return movie;
            
        }
    }
}
