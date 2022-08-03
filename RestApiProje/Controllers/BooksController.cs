using Microsoft.AspNetCore.Mvc;
using RestApiProje.ModelsDto;
using RestApiProje.Repositories;

namespace RestApiProje.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _BookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookModelDto>> GetBooks()
        {
            var result = _BookRepository.GetAll();
            if (result == null)
                return NotFound();
            return result.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<BookModelDto> GetBook(long id)
        {
            var result = _BookRepository.GetById(id);
            if (result == null)
                return NotFound();
            return result;
        }
        [HttpPost]
        public ActionResult AddBook(CreateUpdateBookModelDto book)
        {
            if (ModelState.IsValid == false)
                return BadRequest();
            _BookRepository.Create(book);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateBook(long id, CreateUpdateBookModelDto book)
        {
            if (ModelState.IsValid == false)
                return BadRequest();
            var result = _BookRepository.GetById(id);
            if (result == null)
                return NotFound();
            _BookRepository.Update(id,book);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(long id)
        {
            var result = _BookRepository.GetById(id);
            if (result == null)
                return NotFound();
            _BookRepository.Delete(id);
            return Ok();
        }
    }
}
