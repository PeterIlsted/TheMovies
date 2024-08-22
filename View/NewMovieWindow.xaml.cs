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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheMovies.Model;
using TheMovies.ViewModel;

namespace TheMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewMovieWindow : Window
    {
        public NewMovieViewModel vm = new NewMovieViewModel();
        MovieRepoViewModel rvm;
        object movie { get; set; }
        public NewMovieWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            movie = vm.Save();
            DialogResult = true;
        }
        public object GetMovie() 
        {
            
            return movie;
        }
    }
}
