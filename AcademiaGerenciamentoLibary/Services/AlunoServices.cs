using AcademiaGerenciamentoLibary.Domain;
using AcademiaGerenciamentoLibary.DTO;
using AcademiaGerenciamentoLibary.Repository.Interfaces;
using AcademiaGerenciamentoLibary.Services.Interfaces;
using AutoMapper;
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

        public AlunoServices(IAlunoRepository alunoRepository, IUnitOfWork unityOfWork, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        //Implementação - comunicação IUnitOfWork

    }
}
