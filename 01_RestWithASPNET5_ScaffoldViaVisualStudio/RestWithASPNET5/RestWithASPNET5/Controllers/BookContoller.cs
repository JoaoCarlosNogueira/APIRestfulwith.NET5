using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Business.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/book/v{version:apiVersion}")]

    public class BookContoller:ControllerBase
    {
        private readonly ILogger<BookContoller> logger;
        private IbookBusiness bookService;

        public BookContoller(ILogger<BookContoller> logger, IbookBusiness bookBusiness)
        {
            this.logger = logger;
            this.bookService = bookBusiness;
        }
        [HttpGet()]
        public IActionResult Get()
        {

            return Ok(bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);

        }

        [HttpPost()]
        public IActionResult Post([FromBody] BookVO bookVO)
        {
            if (bookVO == null)
            {
                return BadRequest();
            }
            return Ok(bookService.Create(bookVO));

        }

        [HttpPut("")]
        public IActionResult Put([FromBody] BookVO bookVO)
        {
            if (bookVO == null)
            {
                return BadRequest();
            }
            return Ok(bookService.Update(bookVO));


        }
        [HttpDelete()]
        public IActionResult Delete(long id)
        {
            bookService.Delete(id);
            return NoContent();

        }
    }
}
