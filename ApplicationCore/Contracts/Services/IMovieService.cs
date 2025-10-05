using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        List<MovieCard> Get30HighestGrossingMovies() {
            var movies = new List<MovieCard>
            {
                new MovieCard { Title = "Inception", Id = 1, PosterUrl = "1"},
                new MovieCard { Title = "Interstellar", Id = 2, PosterUrl = "2"}
            };
            return movies;
        }
    }
}
