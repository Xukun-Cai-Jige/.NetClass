using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext) { }
        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public IEnumerable<Movie> Get30HighestRatedMovies()
        {
            throw new NotImplementedException();
        }

        public async override Task<Movie> GetById(int id)
        {
            //var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            var movie = await _dbContext.Movies.Include(m => m.GenresOfMovie).ThenInclude(mg => mg.Genre).Include(m => m.Trailers).Include(m => m.CastsOfMovie).ThenInclude(mg =>mg.Cast).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) { return null; }
            movie.Rating = await _dbContext.Reviews.Where(m => m.MovieId == id).AverageAsync(m => m.Rating);
            return movie;
        }

        public async Task<PagedReusltSet<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var totalMovieCountByGenre = await _dbContext.MovieGenres
                    .Where(m => m.GenreId == genreId)
                    .CountAsync();
            if (totalMovieCountByGenre == 0)
            {
                throw new Exception("No Movies Found For That Genre");
            }
            var movies = await _dbContext.MovieGenres
                    .Where(m => m.GenreId == genreId)
                    .Include(m => m.Movie)
                    .OrderBy(m => m.MovieId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(mg => mg.Movie)
                    .ToListAsync();
            PagedReusltSet<Movie> pagedMovies = new PagedReusltSet<Movie>(movies, pageNumber, pageSize, totalMovieCountByGenre);
            return pagedMovies;
        }
    }
}
