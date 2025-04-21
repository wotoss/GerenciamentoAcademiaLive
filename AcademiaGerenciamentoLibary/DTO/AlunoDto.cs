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
        public string Nome { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Cpf é obrigatorio")]
        [StringLength(11)]
        public string Cpf { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Whatsapp é obrigatório")]
        [StringLength(255)]
        public string Whatsapp { get; set; } = string.Empty;

        public DateTime? DataNascimento { get; set; }

        public virtual ICollection<PagamentoDto> Pagamentos { get; set; } = new List<PagamentoDto>();
    }
}
