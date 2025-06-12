using CONTRACT.API.Models;
using CONTRACT.API.Repository.Interfaces;
using Dapper;
using System.Data;

namespace CONTRACT.API.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly IDbConnection _connection;

        public ContractRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contract> Get()
        {
            var sql = "SELECT * FROM CONTRACT";
            var contracts = _connection.Query<Contract>(sql);
            return contracts;
        }

        public Contract GetById(int id)
        {
            var sql = "SELECT * FROM CONTRACT WHERE ID = @Id";
            var contract = _connection.QueryFirstOrDefault<Contract>(sql, new { Id = id });
            return contract;
        }

        public Contract Create(Contract contract)
        {
            var sql = "INSERT INTO CONTRACT (ID, NAME, CONTRACTBASE64, AUTHOR, ASSIGNED, CREATIONDATE) VALUES (@Id, @Name, @ContractBase64, @Author, @Assigned, @CreationDate)";
            _connection.Execute(sql, new {
                @Id = contract.Id,
                @Name = contract.Name,
                @ContractBase64 = contract.ContractBase64,
                @Author = contract.Author,
                @Assigned = contract.Assigned,
                @CreationDate = contract.CreationDate
            });
            return this.GetById(contract.Id);
        }

        public Contract Update(int id, Contract contract)
        {
            var sql = "UPDATE CONTRACT SET NAME = @Name, CONTRACTBASE64 = @ContractBase64, AUTHOR = @Author, ASSIGNED = @Assigned, CREATIONDATE = @CreationDate WHERE ID = @Id";
            _connection.Execute(sql, new
            {
                @Id = id,
                @Name = contract.Name,
                @ContractBase64 = contract.ContractBase64,
                @Author = contract.Author,
                @Assigned = contract.Assigned,
                @CreationDate = contract.CreationDate
            });
            return this.GetById(id);
        }

        public Contract Delete(int id)
        {
            var existingContract = this.GetById(id);
            var sql = "DELETE FROM CONTRACT WHERE ID = @Id";
            _connection.Execute(sql, new { @Id = id });
            return existingContract;
        }
    }
}
