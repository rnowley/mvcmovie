using System;

namespace mvcmovie.Models {

    public class Movie {

        public Movie(string title, string releaseDate, string genre, string price) {
            Title = title;
            ReleaseDate = releaseDate;
            Genre = genre;
            Price = price;
        }
        
        public int ID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
    }
}