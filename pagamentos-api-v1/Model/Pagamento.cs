using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pagamentos_api_v1.Model
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string NomeTitular { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string NumeroCartao { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string DataExpiracao { get; set; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CVV { get; set; }
    }
}