using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreB.BL.Interfaces;
using MovieStoreB.Models.DTO;
using MovieStoreB.Models.Requests;

namespace MovieStoreB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(
            IMovieService movieService,
            IMapper mapper,
            ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movieService.GetMovies();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest();

            var result =
                _movieService.GetMoviesById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie(
            [FromBody]AddMovieRequest movieRequest)
        {
            if (movieRequest == null) return BadRequest();

            var movie = _mapper.Map<Movie>(movieRequest);

            await _movieService.AddMovie(movie);

            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest($"Wrong id:{id}");

            _movieService.DeleteMovie(id);

            return Ok();
        }
    }
}
