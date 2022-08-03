using Microsoft.EntityFrameworkCore;
using RestApiProje.ModelsDto;

namespace RestApiProje.Context
{
    public class BooksDbManager : DbContext
    {
        public BooksDbManager(DbContextOptions<BooksDbManager> options) : base(options)
        {
        }
        public DbSet<BookModelDto> BooksDb { get; set; }
    }
}
