using RestApiProje.Context;
using RestApiProje.ModelsDto;

namespace RestApiProje.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbManager _BooksDbManager;
        public BookRepository(BooksDbManager BooksDbManager)
        {
            _BooksDbManager = BooksDbManager;
        }

        public IEnumerable<BookModelDto> GetAll()
        { 
            return _BooksDbManager.BooksDb.ToList();
        }

        public BookModelDto GetById(long id)
        {
            return _BooksDbManager.BooksDb.SingleOrDefault(x => x.Id==id);
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
            _BooksDbManager.BooksDb.Add(result);
            _BooksDbManager.SaveChanges();


        }
        public void Delete(long id)
        {
            _BooksDbManager.BooksDb.Remove(_BooksDbManager.BooksDb.FirstOrDefault(x=>x.Id==id));
            _BooksDbManager.SaveChanges();

        }
        public void Update(long id,CreateUpdateBookModelDto book)
        {
            var result= _BooksDbManager.BooksDb.FirstOrDefault(x => x.Id == id);
            result.Name = book.Name;
            result.Genre = book.Genre;
            result.Author = book.Author;
            result.HolderId = book.HolderId;
            result.LastUpdateTime = DateTime.UtcNow;
            _BooksDbManager.SaveChanges();
        }

    }
}
