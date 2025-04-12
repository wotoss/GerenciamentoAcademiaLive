using AcademiaGerenciamentoLibary.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");

            builder.HasKey(pagamento => pagamento.ID);

            builder.Property(pagamento => pagamento.ID)
                .HasColumnName("ID");

            builder.Property(pagamento => pagamento.AlunoID)
                .IsRequired()
                .HasColumnName("AlunoID");

            builder.Property(pagamento => pagamento.DataPagamento)
                .HasColumnType("datetime");

            builder.Property(pagamento => pagamento.ValorPago)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(pagamento => pagamento.MetodoPagamento)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(pagamento => pagamento.StatusPagamento)
                .IsRequired()
                .HasColumnType("tinyint");


            builder.HasOne(pagamento => pagamento.Aluno)
                .WithMany(aluno => aluno.Pagamentos)
                .HasForeignKey(pagamento => pagamento.AlunoID)
                .HasConstraintName("FK_Pagamento_Aluno")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
