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
using System.Linq.Expressions;

namespace TheMovies.View
{
    /// <summary>
    /// Interaction logic for MovieRepoWindow.xaml
    /// </summary>
    public partial class MovieRepoWindow : Window
    {
        public MovieRepoWindow()
        {
            InitializeComponent();
            DialogVisitor visitor = new DialogVisitor();
            MovieRepoViewModel vm = new MovieRepoViewModel(visitor);
            
            DataContext = vm;
        }
    }
}
