using AcademiaGerenciamentoLibary.Domain;
using AcademiaGerenciamentoLibary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.Services.Interfaces
{
    //Contrato
    public interface IAlunoServices
    {
        //Task
        Task<Aluno?> AdicionarAlunoAsync(AlunoDto alunoDto);

        Task<Aluno?> AtualizarAlunoAsync(int id, AlunoDto alunoDto);

        Task<bool> ExcluirAlunoAsync(int id);

        Task<Aluno?> ConsultarAlunoAsync(int id);

        Task<Aluno?> ObterPorIdAsync(int id);
    }
}
