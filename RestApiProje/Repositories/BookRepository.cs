using RestApiProje.Context;
using RestApiProje.ModelsDto;

namespace RestApiProje.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbManager _DbManager;
        public BookRepository(DbManager dbManager)
        {
            _DbManager = dbManager;
        }

        public IEnumerable<BookModelDto> GetAll()
        { 
            return _DbManager.BooksDb.ToList();
        }

        public BookModelDto GetById(long id)
        {
            return _DbManager.BooksDb.SingleOrDefault(x => x.Id==id);
        }

        public void Create(CreateUpdateBookModelDto book)
        {
            var result = new BookModelDto()
            {
                Name = book.Name,
                Genre = book.Genre,
                Author = book.Author,
                HolderId = book.HolderId,
                LastUpdateTime = DateTime.UtcNow
            };
            _DbManager.BooksDb.Add(result);
            _DbManager.SaveChanges();


        }
        public void Delete(long id)
        {
            _DbManager.BooksDb.Remove(_DbManager.BooksDb.FirstOrDefault(x=>x.Id==id));
            _DbManager.SaveChanges();

        }
        public void Update(long id,CreateUpdateBookModelDto book)
        {
            var result= _DbManager.BooksDb.FirstOrDefault(x => x.Id == id);
            result.Name = book.Name;
            result.Genre = book.Genre;
            result.Author = book.Author;
            result.HolderId = book.HolderId;
            result.LastUpdateTime = DateTime.UtcNow;
            _DbManager.SaveChanges();
        }

    }
}
