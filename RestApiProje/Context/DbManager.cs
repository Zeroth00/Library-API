using Microsoft.EntityFrameworkCore;
using RestApiProje.ModelsDto;

namespace RestApiProje.Context
{
    public class DbManager : DbContext
    {
        public DbManager(DbContextOptions<DbManager> options) : base(options)
        {
        }
        public DbSet<BookModelDto> BooksDb { get; set; }
        public DbSet<ClientModelDto> ClientsDb { get; set; }
    }
}
