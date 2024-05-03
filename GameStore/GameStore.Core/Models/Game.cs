using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Models
{
    public class Game
    {
        public const int max_name_lenght = 50;
        public Game(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        public static (Game Game, string Error) Create(Guid id, string name, string description, decimal price)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(name) ||name.Length > max_name_lenght)
            {
                error = "Name can`t be empty or must be shorter than 50 symbols!";
            }

            var game = new Game(id, name, description, price);
            return (game, error);
        }
    }
}
