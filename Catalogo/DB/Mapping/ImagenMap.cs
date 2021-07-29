using Catalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.DB.Mapping
{
    public class ImagenMap : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.ToTable("Imagen");
            builder.HasKey(o => o.id);
        }
    }
}
