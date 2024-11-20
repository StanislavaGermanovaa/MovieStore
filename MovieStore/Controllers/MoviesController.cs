using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.DTO;
using MovieStore.BL.Interfaces;
using MovieStore.BL.Services;
using MovieStore.DL.Interfaces;
namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly IActorRepository _actorRepository;

        public MoviesController(IMoviesService movieService, IActorRepository actorRepository)
        {
            _movieService = movieService;
            _actorRepository = actorRepository;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Movie> Get()
        {
            return _movieService.GetAll();
        }

        [HttpPost("Add")]
        public void Add(Movie movie)
        {
            _movieService.Add(movie);
        }

        [HttpGet("GetAllActors")]
        public IEnumerable<Actor> GetActors()
        {
            return _actorRepository.GetActors();
        }
    }
}
