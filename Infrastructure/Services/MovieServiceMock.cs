using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieServiceMock //: IMovieService
    {
        public List<MovieCard> Get30HighestGrossingMovies()
        {
            var movies = new List<MovieCard>
            {
                new MovieCard { Title = "Inception", Id = 11},
                new MovieCard { Title = "Interstellar", Id = 22}
            };
            return movies;
        }

        public MovieDetailModel GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
