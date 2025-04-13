using AcademiaGerenciamentoLibary.Repository.Interfaces;


namespace AcademiaGerenciamentoLibary
{
    public interface IUnitOfWork
    {
        public DbContextApplication _dbContext { get; set; }

        IAlunoRepository AlunoRepository { get;  }

        IPagamentoRepository PagamentoRepository { get; }

        Task<int> SaveChangesAsync();

        int Salvar();
    }
}
