using GameStore.Application.Services;
using GameStore.Contracts;
using GameStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gameServices;
        public GamesController(IGamesService gameServices)
        {
            _gameServices = gameServices;  
        }

        [HttpGet]
        public async Task<ActionResult<List<GamesResponse>>> GetGames()
        {
            var games = await _gameServices.GetAllGames();

            var response = games.Select(x => new GamesResponse(x.Id, x.Name, x.Description, x.Price));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateGame([FromBody] GamesRequest request)
        {
            var (game, error) = Game.Create(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var gameId = await _gameServices.CreateGame(game);

            return Ok(gameId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateGame(Guid id, [FromBody] GamesRequest request)
        {
            var gameId = await _gameServices.UpdateGame(id, request.Name, request.Description, request.Price);
            return Ok(gameId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteGame(Guid id)
        {
            return Ok(await _gameServices.DeleteGame(id));
        }
    }
}
