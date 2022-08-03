using RestApiProje.ModelsDto;

namespace RestApiProje.Repositories
{
    public interface IClientRepository
    {
        public IEnumerable<ClientModelDto> GetAll();
        public ClientModelDto GetById(long id);
        public void Create(CreateUpdateClientModelDto book);
        public void Update(long id, CreateUpdateClientModelDto book);
        public void Delete(long id);
    }
}
