using AcademiaGerenciamentoLibary.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.DTO
{
    public class AlunoDto
    {
        //public string Nome { get; set; } = string.Empty;

        //[EmailAddress(ErrorMessage = "Formato de email inválido")]
        //[StringLength(100)]
        //public string? Email { get; set; }

        //[Required(ErrorMessage = "Cpf é obrigatorio")]
        //[StringLength(11)]
        //public string Cpf { get; set; } = string.Empty;

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Whatsapp é obrigatório")]
        //[StringLength(255)]
        //public string Whatsapp { get; set; } = string.Empty;

        //public DateTime? DataNascimento { get; set; }

        //public virtual ICollection<PagamentoDto> Pagamentos { get; set; } = new List<PagamentoDto>();


        //[Required]
        //public string Nome { get; set; } = string.Empty;


        //[Required(ErrorMessage = "Cpf é obrigatorio")]
        //[StringLength(11)]
        //public string Cpf { get; set; } = string.Empty;

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Whatsapp é obrigatório")]
        //[StringLength(255)]
        //public string Whatsapp { get; set; } = string.Empty;

        //[EmailAddress]
        //public string? Email { get; set; }

        //public DateTime? DataNascimento { get; set; }

        //public List<PagamentoDto> Pagamentos { get; set; } = new();


       
            [Required(ErrorMessage = "O nome é obrigatório.")]
            [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "O WhatsApp é obrigatório.")]
            [MaxLength(100, ErrorMessage = "O WhatsApp deve ter no máximo 100 caracteres.")]
            public string Whatsapp { get; set; }

            [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
            [MaxLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O CPF é obrigatório.")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 caracteres.")]
            public string Cpf { get; set; }

            public DateTime? DataNascimento { get; set; }

            public byte Status { get; set; } = 1;

            public DateTime? DataCadastro { get; set; }

            public DateTime? DataPagamento { get; set; }

            public List<PagamentoDto> Pagamentos { get; set; } = new List<PagamentoDto>();
        //}
    }
}
