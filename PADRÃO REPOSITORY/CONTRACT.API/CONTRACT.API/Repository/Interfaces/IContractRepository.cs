using CONTRACT.API.Models;

namespace CONTRACT.API.Repository.Interfaces
{
    public interface IContractRepository
    {
        IEnumerable<Contract> Get();
        Contract GetById(int id);
        Contract Create(Contract contract);
        Contract Update(int id, Contract contract);
        Contract Delete(int id);
    }
}
