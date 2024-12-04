using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;
using MovieStore.Models.Requests;
using MovieStore.Models.Response;

namespace MovieStore.BL.Interfaces
{
    public interface IBlMovieService
    {
        List<FullMovieDetails> GetAllMovieDetails();
    }

}
