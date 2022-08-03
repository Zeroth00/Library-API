using Microsoft.AspNetCore.Mvc;
using RestApiProje.ModelsDto;
using RestApiProje.Repositories;

namespace RestApiProje.Controllers
{
    [ApiController]
    [Route("Clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _ClientRepository;
        public ClientsController(IClientRepository clientRepository)
        {
            _ClientRepository = clientRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClientModelDto>> GetBooks()
        {
            var result = _ClientRepository.GetAll();
            if (result == null)
                return NotFound();
            return result.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<ClientModelDto> GetBook(long id)
        {
            var result = _ClientRepository.GetById(id);
            if (result == null)
                return NotFound();
            return result;
        }
        [HttpPost]
        public ActionResult AddBook(CreateUpdateClientModelDto book)
        {
            if(ModelState.IsValid==false)
                return BadRequest();
            _ClientRepository.Create(book);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateBook(long id, CreateUpdateClientModelDto book)
        {
            if (ModelState.IsValid == false)
                return BadRequest();
            var result = _ClientRepository.GetById(id);
            if (result == null)
                return NotFound();
            _ClientRepository.Update(id, book);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(long id)
        {
            var result = _ClientRepository.GetById(id);
            if (result == null)
                return NotFound();
            _ClientRepository.Delete(id);
            return Ok();
        }
    }
}
