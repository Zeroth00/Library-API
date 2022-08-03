
using RestApiProje.ModelsDto;

namespace RestApiProje.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<BookModelDto> GetAll();
        public BookModelDto GetById(long id);
        public void Create(CreateUpdateBookModelDto book);
        public void Update(long id,CreateUpdateBookModelDto book);
        public void Delete(long id);
    }
}
