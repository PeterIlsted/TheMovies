using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using TheMovies.Repository;


namespace TheMovies.Model
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Map(m => m.Title).Name("Titel");
            Map(m => m.Duration).Name("Varighed"); // Mapped to the correct header in CSV
            Map(m => m.Genre).Name("Genre");

        }
    }
    public class DataHandler
    {
        private string FileName = "TheMoviesMovies.csv";
        //private string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private string DocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        public DataHandler() { }
        public List<Movie> GetMovies()
        {
            Movie movie;
            List<Movie> movies = new List<Movie>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
            using (var reader = new StreamReader(Path.Combine(DocPath, FileName)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<MovieMap>();
                var records = csv.GetRecords<Movie>().ToList();
                movies.AddRange(records);
            }
            return movies;
        }

        public List<Movie> GetMovies(string filePath)
        {
            Movie movie;
            List<Movie> movies = new List<Movie>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<MovieMap>();
                var records = csv.GetRecords<Movie>().ToList();
                movies.AddRange(records);
            }
            return movies;
        }
        public void SaveMovies(List<Movie> movies) //tilføjet metode til gem til csv
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };


            using (var writer = new StreamWriter(Path.Combine(DocPath, FileName)))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<MovieMap>();
                csv.WriteRecords(movies); // Skriv filmdata til CSV filen
            }
        }

    }
}