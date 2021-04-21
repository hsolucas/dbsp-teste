using System;
using System.Collections.Generic;
using System.Linq;
using api_contas.DAL;
using api_contas.Models;

namespace api_contas.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ApiContasContext _context;
        private readonly IContaRepository _cRepo;

        public LancamentoRepository(ApiContasContext context, IContaRepository cRepo)
        {
            _context = context;
            _cRepo = cRepo;
        }

        public IEnumerable<Lancamento> GetAll()
        {
            return _context.Lancamentos.ToList();
        }

        public void Lancar(Lancamento l)
        {
            _cRepo.Debitar(l.IdContaOrigem, l.Valor);
            try{
                _cRepo.Creditar(l.IdContaDestino, l.Valor);
                l.Data = DateTime.Now;
                _context.Lancamentos.Add(l);
                _context.SaveChanges();
            }catch(Exception){
                _cRepo.Creditar(l.IdContaOrigem, l.Valor);
            }
        }
    }
}