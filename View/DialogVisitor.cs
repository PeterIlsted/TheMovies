using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
