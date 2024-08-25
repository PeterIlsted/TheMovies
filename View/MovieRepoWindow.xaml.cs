using Microsoft.Win32;
using System.Windows;
using TheMovies.ViewModel;
using TheMovies.Repository;
using TheMovies.Model;

namespace TheMovies.View
{
    public partial class MovieRepoWindow : Window
    {
        private MovieRepoViewModel viewModel;

        public MovieRepoWindow()
        {
            InitializeComponent();

            string placeholderFilePath = "Uge33-TheMovies.CSV";  // Placeholder eller standard filsti
            viewModel = new MovieRepoViewModel(new DialogVisitorImpl(), new MovieRepository(), new DataHandler(placeholderFilePath));
            DataContext = viewModel;
        }

        private void OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Select a CSV file"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Update DataHandler with the selected file path
                viewModel.DataHandler = new DataHandler(openFileDialog.FileName);

                if (viewModel.OpenFileCommand.CanExecute(null))
                {
                    viewModel.OpenFileCommand.Execute(null);
                }
               
            }

        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog();
        }
    }
}