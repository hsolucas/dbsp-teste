using System.Collections.Generic;
using api_contas.Models;

namespace api_contas.Repositories
{
    public interface ILancamentoRepository
    {
        void Lancar(Lancamento l);
        IEnumerable<Lancamento> GetAll();
    }
}