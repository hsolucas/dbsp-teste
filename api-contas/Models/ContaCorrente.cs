using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_contas.Models
{
    public class ContaCorrente
    {
        public ContaCorrente(){}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long Numero { get; set; }
        public short Digito { get; set;}
        public long Agencia { get; set; }
        public double Saldo {get; set;} 
    }
}