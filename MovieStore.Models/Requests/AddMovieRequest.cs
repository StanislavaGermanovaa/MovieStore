using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Models.Requests
{
    public class AddMovieRequest
    {
        public required string Title { get; set; }

        public int Year { get; set; }
    }
}
