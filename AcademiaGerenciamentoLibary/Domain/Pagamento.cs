
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcademiaGerenciamentoLibary.Domain
{
    public class Pagamento
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
    }
}
