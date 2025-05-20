using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaData.TableConfig
{
    public class TransferenciaTableConfig : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("Transferencia");

            builder.HasKey(transferencia => transferencia.Id);

            builder.Property(transferencia => transferencia.Data);

            builder.Property(transferencia => transferencia.CarteiraRemetenteId);

            builder.Property(transferencia => transferencia.CarteiraDestinatarioId);               
        }
    }
}
