using Microsoft.EntityFrameworkCore;
using api_contas.Models;

namespace api_contas.DAL
{
    public class ApiContasContext : DbContext
    {
        public ApiContasContext(DbContextOptions<ApiContasContext> options)
            : base(options)
        {
        }

        public DbSet<ContaCorrente> Contas { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}