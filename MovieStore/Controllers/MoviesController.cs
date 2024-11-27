using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.DTO;
using MovieStore.BL.Interfaces;
using MapsterMapper;
using MovieStore.Models.Requests;
namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Movie> Get()
        {
            return _movieService.GetAll();
        }

        [HttpPost("Add")]
        public void Add([FromBody]AddMovieRequest movieRequest)
        {
            var movie=_mapper.Map<Movie>(movieRequest);
            _movieService.Add(movie);
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            _movieService.DeleteMovieById(id);
        }
    }
}
