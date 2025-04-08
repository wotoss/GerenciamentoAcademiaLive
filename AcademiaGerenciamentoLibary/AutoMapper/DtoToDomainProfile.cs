using AcademiaGerenciamentoLibary.DTO;
using AutoMapper;
using AcademiaGerenciamentoLibary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.AutoMapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<AlunoDto, Aluno>();
            CreateMap<PagamentoDto, Pagamento>();
        }
    }
}
