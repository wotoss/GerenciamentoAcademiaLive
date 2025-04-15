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
        //AddAsync
    }
}
