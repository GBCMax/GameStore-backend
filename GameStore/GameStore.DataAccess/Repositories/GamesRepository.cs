using GameStore.Core.Models;
using GameStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GameStoreDbContext _db;
        public GamesRepository(GameStoreDbContext context)
        {
            _db = context;
        }
        public async Task<List<Game>> Get()
        {
            var gameEntities = await _db.Games
                .AsNoTracking()
                .ToListAsync();

            var games = gameEntities
                .Select(x => Game.Create(x.Id, x.Name, x.Description, x.Price).Game)
                .ToList();

            return games;
        }
        public async Task<Guid> Create(Game game)
        {
            var gameEntity = new GameEntity
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price
            };

            await _db.Games.AddAsync(gameEntity);
            await _db.SaveChangesAsync();

            return gameEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description, decimal price)
        {
            await _db.Games
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(y => y
                .SetProperty(x => x.Name, x => name)
                .SetProperty(x => x.Description, x => description)
                .SetProperty(x => x.Price, x => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _db.Games
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
