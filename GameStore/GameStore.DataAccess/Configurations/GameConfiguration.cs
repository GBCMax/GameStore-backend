using GameStore.Core.Models;
using GameStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(y => y.Name)
                .HasMaxLength(Game.max_name_lenght)
                .IsRequired();

            builder.Property(y => y.Description)
                .IsRequired();

            builder.Property(y => y.Price)
                .IsRequired();
        }
    }
}
