using Catalogo.DB.Mapping;
using Catalogo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.DB
{
    public class CatalogoContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new ProductosMap());
            modelBuilder.ApplyConfiguration(new ImagenMap());
        }
    }
}
