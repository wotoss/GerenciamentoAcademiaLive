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
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new PagamentoMapping());
        }
        //DbSet
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

    }

}
