using GameStore.Core.Models;
using GameStore.DataAccess.Repositories;

namespace GameStore.Application.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        public GamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }
        public async Task<List<Game>> GetAllGames()
        {
            return await _gamesRepository.Get();
        }

        public async Task<Guid> CreateGame(Game game)
        {
            return await _gamesRepository.Create(game);
        }

        public async Task<Guid> UpdateGame(Guid id, string name, string description, decimal price)
        {
            return await _gamesRepository.Update(id, name, description, price);
        }
        public async Task<Guid> DeleteGame(Guid id)
        {
            return await _gamesRepository.Delete(id);
        }
    }
}
