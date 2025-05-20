using AcademiaGerenciamentoLibary.Domain;
using AcademiaGerenciamentoLibary.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary
{
    public class DbContextApplication : DbContext
    {
        public DbContextApplication(DbContextOptions<DbContextApplication> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Aluno>()
            //    .HasMany(a => a.Pagamentos)
            //    .WithOne(p => p.Aluno!)
            //    .HasForeignKey(p => p.AlunoID);

            modelBuilder.Entity<Pagamento>()
               .HasOne(p => p.Aluno)
               .WithMany(a => a.Pagamentos)
               .HasForeignKey(p => p.AlunoID)
               .OnDelete(DeleteBehavior.Restrict); // ou .SetNull ou .NoAction, dependendo da lógica desejada

            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new PagamentoMapping());
        }
        //DbSet
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

    }

}
