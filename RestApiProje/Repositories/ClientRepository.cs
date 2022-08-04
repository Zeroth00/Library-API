using RestApiProje.Context;
using RestApiProje.ModelsDto;

namespace RestApiProje.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbManager _DbManager;
        public ClientRepository(DbManager ClientsDbManager)
        {
            _DbManager = ClientsDbManager;
        }

        public IEnumerable<ClientModelDto> GetAll()
        {
            return _DbManager.ClientsDb.ToList();
        }

        public ClientModelDto GetById(long id)
        {
            return _DbManager.ClientsDb.SingleOrDefault(x => x.Id == id);
        }

        public void Create(CreateUpdateClientModelDto client)
        {
            var result = new ClientModelDto()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.LastName,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber
                
            };
            _DbManager.ClientsDb.Add(result);
            _DbManager.SaveChanges();


        }
        public void Delete(long id)
        {
            _DbManager.ClientsDb.Remove(_DbManager.ClientsDb.FirstOrDefault(x => x.Id == id));
            _DbManager.SaveChanges();

        }
        public void Update(long id, CreateUpdateClientModelDto client)
        {
            var result = _DbManager.ClientsDb.FirstOrDefault(x => x.Id == id);
            result.FirstName = client.FirstName;
            result.LastName = client.LastName;
            result.Address = client.LastName;
            result.Email = client.Email;
            result.PhoneNumber = client.PhoneNumber;
            _DbManager.SaveChanges();
        }

    }
}
