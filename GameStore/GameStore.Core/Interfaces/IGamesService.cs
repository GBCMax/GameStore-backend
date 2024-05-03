using GameStore.Core.Models;

namespace GameStore.Application.Services
{
    public interface IGamesService
    {
        Task<Guid> CreateGame(Game game);
        Task<Guid> DeleteGame(Guid id);
        Task<List<Game>> GetAllGames();
        Task<Guid> UpdateGame(Guid id, string name, string description, decimal price);
    }
}