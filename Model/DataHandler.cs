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
        private readonly string filePath = "C:\\Users\\pibm9\\OneDrive - UCL Erhvervsakademi og Professionshøjskole\\Dokumenter\\Datamatiker\\Programmering\\2. semester\\TheMovies";
        

        public DataHandler(string filePath)
        {
            this.filePath = filePath;
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            

        }
        public DataHandler() 
        {
            

        }
        public List<Movie> GetMovies()
        {
            Movie movie;
            List<Movie> movies = new List<Movie>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
            using (var reader = new StreamReader("C:\\Users\\pibm9\\OneDrive - UCL Erhvervsakademi og Professionshøjskole\\Dokumenter\\Datamatiker\\Programmering\\2. semester\\TheMovies\\TheMoviesMovies.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<MovieMap>();
                var records = csv.GetRecords<Movie>().ToList();
                movies.AddRange(records);
            }
            return movies;
        }

        // Læs data fra CSV-fil og konverter til en liste af Movie objekter
        
    }
}