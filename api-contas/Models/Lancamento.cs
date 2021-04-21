using System;

namespace api_contas.Models
{
    public class Lancamento
    {
        public long Id { get; set; }
        public long IdContaOrigem { get; set; }
        public long IdContaDestino { get; set; }
        public float Valor { get; set; }
        public DateTime? Data {get; set;}
 
    }
}