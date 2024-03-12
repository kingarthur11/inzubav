using Microsoft.AspNetCore.Mvc;

namespace jvconsult.Models
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task CreateMovie(Movie movie);
        Task UpdateMovie(int? id, Movie movie);
        Task DeleteMovie(int? id);
        Task SearchMovie(string poster, string imdbscore);
    }
}
