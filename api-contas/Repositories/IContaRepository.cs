using System.Collections.Generic;
using api_contas.Models;

namespace api_contas.Repositories
{
    public interface IContaRepository
    {
        IEnumerable<ContaCorrente> GetAll();
        ContaCorrente Find(long id);
        void Debitar(long idConta, double valor);
        void Creditar(long idConta, double valor);
    }
}