

namespace MovieStore.Models.Requests
{
    public class AddMovieRequest
    {
        public required string Title { get; set; }

        public int Year { get; set; }

        public List<string> ActorIds { get; set; }
    }
}
