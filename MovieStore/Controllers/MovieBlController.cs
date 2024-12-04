using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.BL.Interfaces;
using MovieStore.BL.Services;
using MovieStore.Models.DTO;

namespace MovieStore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MoviesBlController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesBlController(
            IMoviesService movieService,
            ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

     
        [HttpGet("GetAll")]
        public IEnumerable<Movie> GetAll()
        {
            try
            {
                //code
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in GetAll {e.Message}-{e.StackTrace}");
            }
            return _movieService.GetAll();
        }
    }

}
