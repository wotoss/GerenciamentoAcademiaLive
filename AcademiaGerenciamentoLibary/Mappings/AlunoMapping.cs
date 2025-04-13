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
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder) 
        {
            builder.ToTable("Aluno");

            builder.HasKey(aluno => aluno.ID);

            builder.Property(aluno => aluno.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(aluno => aluno.Whatsapp)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(aluno => aluno.Email)
                .HasMaxLength(100);

            builder.Property(aluno => aluno.Cpf)
                .IsRequired()
                .HasColumnType("char(11)");

            builder.Property(aluno => aluno.DataNascimento)
                .HasColumnType("date");

            builder.Property(aluno => aluno.Status)
                .IsRequired()
                .HasDefaultValue((byte)1);

            builder.Property(aluno => aluno.DataCadastro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");


            builder.Property(aluno => aluno.DataPagamento)
                .HasColumnType("date");

            builder.HasMany(aluno => aluno.Pagamentos)
                .WithOne(pag => pag.Aluno)
                .HasForeignKey(pag => pag.AlunoID);
        }
    }
}
