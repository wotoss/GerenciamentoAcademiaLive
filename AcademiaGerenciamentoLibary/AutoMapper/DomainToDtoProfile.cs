using AcademiaGerenciamentoLibary.Domain;
using AcademiaGerenciamentoLibary.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.AutoMapper
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Aluno, AlunoDto>();
            CreateMap<Pagamento, PagamentoDto>();
        }
    }
}
