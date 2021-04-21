using System;
using System.Collections.Generic;
using System.Linq;
using api_contas.DAL;
using api_contas.Models;

namespace api_contas.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly ApiContasContext _context;

        public ContaRepository(ApiContasContext context)
        {
            _context = context;
            //carregar contas iniciais para exemplo
            if(_context.Contas.Count() == 0){
                this.Add(
                    new ContaCorrente {
                    Agencia = 10,
                    Numero = 123,
                    Digito = 1,
                    Saldo = 155.42 
                    }
                );
                this.Add(
                    new ContaCorrente {
                    Agencia = 25,
                    Numero = 246,
                    Digito = 0,
                    Saldo = 1600.00 
                    }
                );
                this.Add(
                    new ContaCorrente {
                    Agencia = 25,
                    Numero = 332,
                    Digito = 9,
                    Saldo = 0.95 
                    }
                );
            }
        }

        public IEnumerable<ContaCorrente> GetAll()
        {
            return _context.Contas.ToList();
        }

        public void Add(ContaCorrente item)
        {
            _context.Contas.Add(item);
            _context.SaveChanges();
        }

        public ContaCorrente Find(long id)
        {
            var conta = _context.Contas.Find(id);
            if(conta  == null){
                throw new Exception($"Conta ID {id} inexistente");
            }
            return conta;
        }
        public void Debitar(long id, double valor)
        {
            var conta = this.Find(id);
            conta.Saldo -= valor;
            if(conta.Saldo < 0){
                throw new Exception("Saldo insuficiente");
            }
            _context.Contas.Update(conta);
            _context.SaveChanges();
        }

        public void Creditar(long id, double valor)
        {
            var conta = this.Find(id);
            conta.Saldo += valor;
            _context.Contas.Update(conta);
            _context.SaveChanges();
        }

    }
}