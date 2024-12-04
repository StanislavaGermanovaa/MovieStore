using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.BL.Services
{
    public class BLMovieService : IBlMovieService
    {
        private readonly IMoviesService _moviesService;
        private readonly IActorRepository _actorRepository;

        public BLMovieService(IMoviesService moviesService, IActorRepository actorRepository)
        {
            _moviesService = moviesService;
            _actorRepository = actorRepository;
        }

        public List<FullMovieDetails> GetAllMovieDetails()
        {
            var result = new List<FullMovieDetails>();

            var movies = _moviesService.GetAll();
  

            foreach (var movie in movies)
            {
                var movieDetails = new FullMovieDetails();
                movieDetails.Title = movie.Title;
                movieDetails.Year = movie.Year;
                movieDetails.Id = movie.Id;

                foreach (var actorId in movie.Actors)
                {
                    var actor = _actorRepository.GetById(actorId);
                }

            }
            return result;
        }
    }
}
