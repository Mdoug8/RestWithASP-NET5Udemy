using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RetWithASPNETUdemy.Business;
using RetWithASPNETUdemy.Data.VO;
using RetWithASPNETUdemy.Hypermedia.Filters;

namespace RetWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        // declaracao do servico utilizado
        private IBookBusiness _bookBusiness;

        //Injencao de uma instancia de IBookBusiness
        // ao criar uma instancia de BookController

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        //Mapeia solicitacoes Get para https: // localhost: {port} / api / book
        // sem parametros para FindAll 

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get (long id)
        {
            var book = _bookBusiness.FindById(id);
            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post ([FromBody] BookVO book)
        {
            if(book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put ([FromBody] BookVO book)
        {
            if(book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
