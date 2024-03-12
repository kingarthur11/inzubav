using jvconsult.Context;
using jvconsult.Models;
using Microsoft.AspNetCore.Mvc;

namespace jvconsult.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repository;

        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<List<Movie>> Index() => await _repository.GetAll();
        [HttpGet("{id}")]
        public Task<Movie> GetById(int id)
        {
            var movie = _repository.GetById(id);
            return movie;
        }
        [HttpPost]
        public async Task CreateMovie(Movie movie)
        {
            await _repository.CreateMovie(movie);
            Ok(new { message = "Movie updated" });
        }
        [HttpPut("{id}")]
        public async Task UpdateMovie(int id, Movie movie)
        {
            await _repository.UpdateMovie(id, movie);
            Ok(new { message = "Movie updated" });
        }
        [HttpDelete]
        public async Task DeleteMovie(int id)
        {
          await _repository.DeleteMovie(id);
          Ok(new { message = "Movie deleted" });  
        }
        [HttpGet("search")]
        public async Task SearchMovie([FromQuery(Name = "poster")] string poster, [FromQuery(Name = "imbdscore")] string imbdscore)
        {
           await _repository.SearchMovie(poster, imbdscore);
        }
    }
}
