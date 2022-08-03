using RestApiProje.Context;
using RestApiProje.ModelsDto;

namespace RestApiProje.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsDbManager _ClientsDbManager;
        public ClientRepository(ClientsDbManager ClientsDbManager)
        {
            _ClientsDbManager = ClientsDbManager;
        }

        public IEnumerable<ClientModelDto> GetAll()
        {
            return _ClientsDbManager.ClientsDb.ToList();
        }

        public ClientModelDto GetById(long id)
        {
            return _ClientsDbManager.ClientsDb.SingleOrDefault(x => x.Id == id);
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
            _ClientsDbManager.ClientsDb.Add(result);
            _ClientsDbManager.SaveChanges();


        }
        public void Delete(long id)
        {
            _ClientsDbManager.ClientsDb.Remove(_ClientsDbManager.ClientsDb.FirstOrDefault(x => x.Id == id));
            _ClientsDbManager.SaveChanges();

        }
        public void Update(long id, CreateUpdateClientModelDto client)
        {
            var result = _ClientsDbManager.ClientsDb.FirstOrDefault(x => x.Id == id);
            result.FirstName = client.FirstName;
            result.LastName = client.LastName;
            result.Address = client.LastName;
            result.Email = client.Email;
            result.PhoneNumber = client.PhoneNumber;
            _ClientsDbManager.SaveChanges();
        }

    }
}
