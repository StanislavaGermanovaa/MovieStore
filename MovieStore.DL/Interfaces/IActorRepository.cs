using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetActors();

        Actor GetById(int id);
       // object GetById(int actorId);
    }
}
