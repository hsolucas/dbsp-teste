using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_contas.Models;
using api_contas.Repositories;

namespace api_contas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {

        private readonly IContaRepository _contaRepo;

        public ContaController(IContaRepository rep)
        {
            _contaRepo = rep;
        }

       [HttpGet]
       public IEnumerable<ContaCorrente> GetAll()
       {
            return _contaRepo.GetAll();
       }

    }
}
