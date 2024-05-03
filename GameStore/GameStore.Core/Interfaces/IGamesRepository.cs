using GameStore.Core.Models;

namespace GameStore.DataAccess.Repositories
{
    public interface IGamesRepository
    {
        Task<Guid> Create(Game game);
        Task<Guid> Delete(Guid id);
        Task<List<Game>> Get();
        Task<Guid> Update(Guid id, string name, string description, decimal price);
    }
}