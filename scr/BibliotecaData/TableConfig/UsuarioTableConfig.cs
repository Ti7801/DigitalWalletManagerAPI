using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaData.TableConfig
{
    public class UsuarioTableConfig : IEntityTypeConfiguration<Usuario>
    {   
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasMany<CarteiraDigital>()
                .WithOne()
                .HasForeignKey(carteiraDigital => carteiraDigital.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);
        }     
    }
}
