using AcademiaGerenciamentoLibary.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaGerenciamentoLibary.DTO
{
    public class PagamentoDto
    {
        //[Key]
        //public int ID { get; set; }
        //[Required]
        //public int AlunoID { get; set; }
        //public DateTime? DataPagamento { get; set; }
        //[Required]
        //[Column(TypeName = "decimal(10,2)")]
        //public decimal ValorPago { get; set; }
        //[StringLength(50)]
        //public string MetodoPagamento { get; set; } = string.Empty;
        //public byte StatusPagamento { get; set; }
        ////relacionamento - cada pagamento estará ligado a um unico aluno
        //[ForeignKey("AlunoID")]
        //public virtual Aluno? Aluno { get; set; }
        //// - Cada - pagamento possui um unico aluno
        ///

        //[Required]
        //public decimal ValorPago { get; set; }

        //public DateTime? DataPagamento { get; set; }

        //[Required]
        //public string MetodoPagamento { get; set; } = string.Empty;

        //public byte StatusPagamento { get; set; }


        [Required(ErrorMessage = "O valor do pagamento é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal ValorPago { get; set; }

        [Required(ErrorMessage = "O método de pagamento é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O método de pagamento deve ter no máximo 50 caracteres.")]
        public string MetodoPagamento { get; set; }

        [Required(ErrorMessage = "A data do pagamento é obrigatória.")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "O status do pagamento é obrigatório.")]
        [Range(0, 255, ErrorMessage = "O status deve ser um valor entre 0 e 255.")]
        public byte StatusPagamento { get; set; }
    }
}
