using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Repository;
using TheMovies.ViewModel;

namespace TheMovies.View
{
    

    public class DialogVisitorImpl : IDialogVisitor
    {
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
