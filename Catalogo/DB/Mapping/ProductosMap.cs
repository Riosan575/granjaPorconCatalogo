using Catalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.DB.Mapping
{
    public class ProductosMap: IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(o => o.id);

            builder.HasMany(o => o.Imagenes)
                .WithOne()
                .HasForeignKey(o => o.idProductos);
        }
    }
}
