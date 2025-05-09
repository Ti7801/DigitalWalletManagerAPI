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
    public class CarteiraDigitalTableConfig : IEntityTypeConfiguration<CarteiraDigital>
    {
        public void Configure(EntityTypeBuilder<CarteiraDigital> builder)
        {
            builder.ToTable("CarteirasDigitais");

            builder.HasKey(carteiraDigital => carteiraDigital.Id);

            builder.Property(carteiraDigital => carteiraDigital.Saldo)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.HasMany<Transferencia>()
                .WithOne()
                .HasForeignKey(transferencia => transferencia.CarteiraRemetenteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany<Transferencia>()
                .WithOne()
                .HasForeignKey(transferencia => transferencia.CarteiraDestinatarioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
