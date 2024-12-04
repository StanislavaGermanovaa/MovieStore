using MovieStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Models.Response
{
    public class FullMovieDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public int Year {  get; set; }
        public List<Actor> Actors { get; set; }
    }
}
