
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiaGerenciamentoLibary.Domain
{
    [Table("Aluno")]
    public class Aluno
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

        // - 1:N - Aluno pode ter vários pagamento
        // - Cada - pagamento possui um unico aluno
        public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}
