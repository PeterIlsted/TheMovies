using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheMovies.Repository;

namespace TheMovies.View
{
    internal class DialogVisitor : ViewModel.DialogVisitor
    {
        // Created a DialogVisitor interface, inspired by the Visitor pattern, to allow the MovieRepoVM to instantiate new Dialog windows through the View layer.
        public Movie DynamicVisit(Movie data) 
        {
            return Visit(data);
        }
        private Movie Visit(Movie movie)
        {
            var dlg = new NewMovieWindow();
            dlg.DataContext = movie;
            dlg.ShowDialog();
            return movie;
        }
        public string DynamicVisit(OpenFileDialog window)
        {
            return (Visit(window));
        }
        private string Visit(OpenFileDialog window)
        {
            string fileName = "";
            window = new OpenFileDialog()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Select a CSV file"
            };
            if (window.ShowDialog() == true)
            {
                fileName = window.FileName;
            }
            return fileName;
        }
    }
}
