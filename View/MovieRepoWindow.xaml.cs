using Microsoft.Win32;
using System.Windows;
using TheMovies.ViewModel;
using TheMovies.Repository;
using TheMovies.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Collections.ObjectModel;

namespace TheMovies.View
{
    public partial class MovieRepoWindow : Window
    {
        private MovieRepoViewModel viewModel;

        public MovieRepoWindow()
        {
            InitializeComponent();
            string placeholderFilePath = null;
            viewModel = new MovieRepoViewModel(new DialogVisitorImpl(), new MovieRepository());
            DataContext = viewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) //Tilføjet metode til "gem" knap
        {
            // Angiv den ønskede filsti
            string filePath = @"C:\Users\sero-\Koder\Movies Datahandler\TheMovies-9370c022aea8f2ee94de415d14ce2099ae110afb\NewMovies.csv";

            // Find DataGrid i XAML
            var dataGrid = this.FindName("MovieRepoGrid") as DataGrid;

            if (dataGrid != null)
            {
                // Cast ItemsSource til en ObservableCollection af Movie objekter
                var movies = dataGrid.ItemsSource as ObservableCollection<Movie>;

                if (movies != null && movies.Any())
                {
                    var movieList = movies.ToList(); // Konverter til List<Movie>

                    try
                    {
                        var dataHandler = new DataHandler(); // Initialiser DataHandler uden filsti
                                                             // Gem movies til CSV
                        dataHandler.SaveMovies(movieList, filePath);
                        MessageBox.Show("Movies saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("No movies found to save.");
                }
            }
            else
            {
                MessageBox.Show("DataGrid not found.");
            }
        }

        private void OpenFileDialog()
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog
            //{
            //    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
            //    Title = "Select a CSV file"
            //};

            //if (openFileDialog.ShowDialog() == true)
            //{
            //    // Update DataHandler with the selected file path
            //    viewModel.DataHandler = new DataHandler(openFileDialog.FileName);

            //    if (viewModel.OpenFileCommand.CanExecute(null))
            //    {
            //        viewModel.OpenFileCommand.Execute(null);
            //    }
               
            //}

        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog();
        }
    }
}