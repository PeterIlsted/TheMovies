using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TheMovies.Repository;

namespace TheMovies.Model
{
    public class DataHandler
    {
        private readonly string filePath;

        public DataHandler(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            this.filePath = filePath;
        }

        // Læs data fra CSV-fil og konverter til en liste af Movie objekter
        public List<Movie> LoadMovies()
        {
            var movies = new List<Movie>();

            if (!File.Exists(filePath))
                return movies;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1)) // Skip header row
            {
                var values = line.Split(',');
                if (values.Length != 4) continue; // Skip invalid lines

                if (!int.TryParse(values[0], out int id))
                    continue; // Skip lines with invalid ID

                string title = values[1];

                if (!TimeSpan.TryParseExact(values[2], @"hh\:mm\:ss", CultureInfo.InvariantCulture, out TimeSpan duration))
                    continue; // Skip lines with invalid duration

                string genre = values[3];

                movies.Add(new Movie(title, duration, genre, id));
            }

            return movies;
        }
    }
}