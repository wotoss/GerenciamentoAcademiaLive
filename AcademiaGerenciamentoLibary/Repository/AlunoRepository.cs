using AcademiaGerenciamentoLibary.Domain;
using AcademiaGerenciamentoLibary.DTO;
using AcademiaGerenciamentoLibary.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DbContextApplication _dbContext;
        private readonly IMapper _mapper;

        public AlunoRepository(DbContextApplication context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<Aluno> AdicionarAlunoAsync(Aluno aluno)
        {
            Debugger.Break();
            await _dbContext.Alunos.AddAsync(aluno);
            return aluno;
        }
        //buscarId
        public async Task<Aluno?> ObterPorIdAsync(int id)
        {
            Debugger.Break();
            return await _dbContext.Alunos.FindAsync(id);
        }
        //updte
        public void AtualizarAluno (Aluno aluno)
        {
            _dbContext.Alunos.Update(aluno);
        }
        public void RemoverAluno(Aluno aluno)
        {
            Debugger.Break();
            _dbContext.Alunos.Remove(aluno);
        }
        
    }
}
