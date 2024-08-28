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
using System.Windows;
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
        private readonly string filePath;
        public DataHandler() { }

        // Constructor with filePath parameter
        public DataHandler(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            this.filePath = filePath;
        }

        public List<Movie> GetMovies()
        {
            var movies = new List<Movie>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };

            using (var reader = new StreamReader(@"C:\Users\sero-\Koder\Movies Datahandler\TheMovies-9370c022aea8f2ee94de415d14ce2099ae110afb\TheMoviesMovies.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<MovieMap>();
                var records = csv.GetRecords<Movie>().ToList();
                movies.AddRange(records);
            }
            return movies;
        }

        public void SaveMovies(List<Movie> movies, string filePath) //tilføjet metode til gem til csv
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };


            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<MovieMap>();
                csv.WriteRecords(movies); // Skriv filmdata til CSV filen
            }
        }
    }
}
