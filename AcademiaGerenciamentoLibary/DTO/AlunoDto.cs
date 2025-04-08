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
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        [Required]
        public byte Status { get; set; } = 1;
        public DateTime? DataPagamento { get; set; } = DateTime.Now;
        public virtual ICollection<PagamentoDto> Pagamentos { get; set; } = new List<PagamentoDto>();
    }
}
