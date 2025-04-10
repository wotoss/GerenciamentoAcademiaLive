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

        //Mapeamento
        //protected override void OnModelCreaating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new AlunoMapping());
        //}
       
    }

}
