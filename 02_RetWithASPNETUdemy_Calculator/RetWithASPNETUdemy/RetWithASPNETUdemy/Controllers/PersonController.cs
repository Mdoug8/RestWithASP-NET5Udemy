using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RetWithASPNETUdemy.Business;
using RetWithASPNETUdemy.Data.VO;
using RetWithASPNETUdemy.Hypermedia.Filters;
using System.Collections.Generic;

namespace RetWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        
        private readonly ILogger<PersonController> _logger;

        //Declaracao do servico utilizado
        private IPersonBusiness _personBusiness;


        // Injencao de uma instancia de IPersonBusiness
        // ao criar uma instancia de PersonController
        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        // Mapeia solicitacoes GET para https: // localhost: {port} / api / person
        // Não obtenha parametros para FindAll -> Pesquisar tudo
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(_personBusiness.FindAll());

        }

        // Mapeia solicitacoes GET para https: // localhost: {port} / api / person / {id}
        // recebendo um ID como no Caminho de Solicitacao
        // Obtenha com parametros para FindById -> Pesquisa por ID
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);

        }

        // Mapeia solicitacoes POST para https: // localhost: {port} / api / person /
        // [FromBody] consome o objeto JSON enviado no corpo da solicitacao

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))] 
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personBusiness.Create(person));
        }

        // Mapeia solicitacoes PUT para https: // localhost: {port} / api / person /
        // [FromBody] consome o objeto JSON enviado no corpo da solicitacao

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personBusiness.Update(person));
        }

        // Mapeia solicitacoes DELETE para https: // localhost: {port} / api / person / {id}
        // recebendo um ID como no Caminho de Solicitacao

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();

        }

    }
}
