using DevIO.Bussines.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {


        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
               .IsRequired()
               .HasColumnType("varchar(14)");

            //Fornecedor para endereço 1:1
                builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            //Forncedor : produtos 1:n
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}

