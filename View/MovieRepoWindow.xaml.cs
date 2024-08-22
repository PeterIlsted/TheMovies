using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheMovies.ViewModel;

namespace TheMovies.View
{
    /// <summary>
    /// Interaction logic for MovieRepoWindow.xaml
    /// </summary>
    public partial class MovieRepoWindow : Window
    {
        public object movie;
        NewMovieWindow movieWindow;
        MovieRepoViewModel vm = new MovieRepoViewModel();
        NewMovieViewModel nvm;
        public MovieRepoWindow()
        {
            InitializeComponent();
            
            DataContext = vm;

        }

        private void Button_Click(object sender, RoutedEventArgs e) // new movie button
        {
            movieWindow = new NewMovieWindow();
            movieWindow.ShowDialog();
            if(movieWindow.DialogResult == true)
            {
                movie = movieWindow.GetMovie();
                vm.AddMovie(movie);
                movieWindow.Close();
            }
        }

    }
}
