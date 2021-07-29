using CRUDAPI.Domain;
using CRUDAPI.Service;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private PessoaService _pessoaService;
        private readonly IConfiguration _configuration;
        public PessoasController(IConfiguration configuration)
        {
            _configuration = configuration;
            _pessoaService = new PessoaService(_configuration);
        }
       

        [HttpGet]
        public ActionResult< List<Pessoa>> PegarTodosAsync()
        {
            return  _pessoaService.GetAll();
        }

        [HttpGet("{pessoaId}")]
        public ActionResult<Pessoa> PegarPessoaPeloIdAsync(int pessoaId)
        {
            Pessoa pessoa = _pessoaService.GetById(pessoaId);


            if (pessoa == null)
                return NotFound();

            return pessoa;
        }

        [HttpPost]
        public ActionResult<Pessoa> SalvarPessoaAsync(Pessoa pessoa)
        {
            _pessoaService.Save(pessoa);

            return Ok();
        }

        [HttpPut]
        public ActionResult AtualizarPessoaAsync(Pessoa pessoa)
        {
            _pessoaService.Update(pessoa);

            return Ok();
        }

        [HttpDelete("{pessoaId}")]
        public ActionResult ExcluirPessoaAsync(int pessoaId)
        {
            Pessoa pessoa = _pessoaService.GetById(pessoaId);
            if (pessoa == null)
                return NotFound();

            _pessoaService.DeleteById(pessoaId);
            return Ok();
        }

    }
}
