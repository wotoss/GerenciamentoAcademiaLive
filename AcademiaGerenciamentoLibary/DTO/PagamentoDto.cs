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
        [Key]
        public int ID { get; set; }
        [Required]
        public int AlunoID { get; set; }
        public DateTime? DataPagamento { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorPago { get; set; }
        [StringLength(50)]
        public string MetodoPagamento { get; set; } = string.Empty;
        public byte StatusPagamento { get; set; }
        //relacionamento - cada pagamento estará ligado a um unico aluno
        [ForeignKey("AlunoID")]
        public virtual Aluno? Aluno { get; set; }
        // - Cada - pagamento possui um unico aluno
    }
}
