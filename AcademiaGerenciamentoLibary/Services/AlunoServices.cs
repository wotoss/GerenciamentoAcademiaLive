using AcademiaGerenciamentoLibary.Domain;
using AcademiaGerenciamentoLibary.DTO;
using AcademiaGerenciamentoLibary.Repository.Interfaces;
using AcademiaGerenciamentoLibary.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.Services
{
    public class AlunoServices : IAlunoServices
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unityOfWork;
        private readonly IMapper _mapper;
        
        public AlunoServices(IAlunoRepository alunoRepository, IUnitOfWork unityOfWork, IMapper mapper, DbContextApplication dbContext)
        {
            _alunoRepository = alunoRepository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<Aluno?> AdicionarAlunoAsync(AlunoDto alunoDto)
        {
            Debugger.Break();

            //chamada
            bool alunoExistente = await _alunoRepository.ExisteCpfAsync(alunoDto.Cpf);
            if (alunoExistente)
            {
                return null;
            }
            
            var aluno = _mapper.Map<Aluno>(alunoDto);

            await _alunoRepository.AdicionarAlunoAsync(aluno);

            await _unityOfWork.CommitAsync();

            return aluno;
        }
        public async Task<Aluno?> AtualizarAlunoAsync(int id, AlunoDto alunoDto)
        {
            Debugger.Break();
            var alunoExistente = await _alunoRepository.ObterPorIdAsync(id);
            if (alunoExistente == null)
            {
                return null;
            }

            _mapper.Map(alunoDto, alunoExistente);

            _alunoRepository.AtualizarAluno(alunoExistente);

            await _unityOfWork.CommitAsync();

            return alunoExistente;
        }

        public async Task<bool> ExcluirAlunoAsync(int id)
        {
            Debugger.Break();
            var alunoExistente = await _alunoRepository.ObterPorIdAsync(id);

            if (alunoExistente == null)
            {
                return false;
            }
            _alunoRepository.RemoverAluno(alunoExistente);
            await _unityOfWork.CommitAsync();

            return true;
        }

        public async Task<Aluno?> ConsultarAlunoAsync(int id)
        {
            Debugger.Break();
            return await _alunoRepository.ObterPorIdAsync(id);
        }

        public async Task<Aluno?> ObterPorIdAsync(int id)
        {
            Debugger.Break();
            return await _alunoRepository.ObterPorIdAsync(id);
        }
        //
        public async Task<IEnumerable<AlunoDto>> ObterTodosAlunosAsync()
        {
            var alunos = await _alunoRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<AlunoDto>>(alunos);
        }
    }
}
