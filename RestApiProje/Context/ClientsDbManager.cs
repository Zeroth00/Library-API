using Microsoft.EntityFrameworkCore;
using RestApiProje.ModelsDto;

namespace RestApiProje.Context
{
    public class ClientsDbManager : DbContext
    {
        public ClientsDbManager(DbContextOptions<ClientsDbManager> options) : base(options)
        {
        }
        public DbSet<ClientModelDto> ClientsDb { get; set; }
    }
}
