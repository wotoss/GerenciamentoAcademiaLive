using AcademiaGerenciamentoLibary.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DbContextApplication _dbContext { get; set; }

        public IAlunoRepository AlunoRepository { get; private set; }

        public IPagamentoRepository PagamentoRepository { get; private set; }

        public UnitOfWork(DbContextApplication dbContext, IAlunoRepository alunoRepository,
            IPagamentoRepository pagamentoRepository)
        {
            _dbContext = dbContext;
            AlunoRepository = alunoRepository;
            PagamentoRepository = pagamentoRepository;
        }
        public async Task<int> SaveChangesAsync()
        {
            Debugger.Break();
            int linhaAfetadas = await _dbContext.SaveChangesAsync();

            return linhaAfetadas;
        }

        public int Salvar()
        {
            try
            {
                int linhasAfetadas = _dbContext.SaveChanges();
                return linhasAfetadas;
            }
            catch (Exception ex)
            {
                var innerEx = ex.InnerException;
                return 0;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            
        }
       
    }
}
