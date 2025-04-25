using AcademiaGerenciamentoLibary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.Repository.Interfaces
{
    public interface IAlunoRepository
    {
        Task<Aluno> AdicionarAlunoAsync(Aluno aluno);
        Task<Aluno?> ObterPorIdAsync(int id);
        void AtualizarAluno(Aluno aluno);
        void RemoverAluno(Aluno aluno);
        Task<bool> ExisteCpfAsync(string cpf);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
    }
}
