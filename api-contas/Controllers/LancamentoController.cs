using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_contas.Models;
using api_contas.Repositories;

namespace api_contas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {        
        
        private readonly ILancamentoRepository _lancamentoRepo;

        public LancamentoController(ILancamentoRepository rep)
        {
            _lancamentoRepo = rep;
        }

       [HttpGet]
       public IEnumerable<Lancamento> GetAll()
       {
            return _lancamentoRepo.GetAll();
       }

        [HttpPost]
        public IActionResult Create([FromBody] Lancamento l)
        {
            if (l == null)
            {
                return BadRequest();
            }
            try{
                _lancamentoRepo.Lancar(l);
            }catch(Exception e){
                return ValidationProblem(e.Message);
            }
            

            return Created(String.Empty, l);
        }

    }
}
