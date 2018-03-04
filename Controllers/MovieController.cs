using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using mvcmovie.Models;

namespace mvcmovie.controllers {

    [Route("movie")]
    public class MovieController : Controller {
        
        [HttpGet("create")]
        public IActionResult Create() {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(string title, string release, string genre, string price) {
            var connection = new SqliteConnection("Data Source=movie.db");
            connection.Open();

            var insertCommandText = 
                @"INSERT INTO movie ( Title, ReleaseDate, Genre, Price )
                  VALUES($title, $releaseDate, $genre, $price)";

            using (var transaction = connection.BeginTransaction()) {
                var insertCommand = connection.CreateCommand();
                insertCommand.Transaction = transaction;
                insertCommand.CommandText = insertCommandText;
                insertCommand.Parameters.AddWithValue("$title", title);
                insertCommand.Parameters.AddWithValue("$releaseDate", release);
                insertCommand.Parameters.AddWithValue("$genre", genre);
                insertCommand.Parameters.AddWithValue("$price", price);
                insertCommand.ExecuteNonQuery();

                transaction.Commit();
            }

            var movie = new Movie(title, release, genre, price);

            return View("SavedSuccess", movie);
        }
    }
}