using Catalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.DB.Mapping
{
    public class AccountMap: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(o => o.id);

            //builder.HasOne(o => o.)
            //    .WithMany()
            //    .HasForeignKey(o => o.);
        }
    }
}
