using CONTRACT.API.Models;
using CONTRACT.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CONTRACT.API.Controllers
{
    [ApiController]
    [Route("api/contract")]
    public class ContractController : ControllerBase
    {
        private readonly IContractRepository _contractRepository;

        public ContractController(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Contract>> Get()
        {
            try
            {
                var contracts = _contractRepository.Get();

                if (contracts == null)
                {
                    return NotFound("Nenhum contrato foi encontrado");
                }

                return Ok(contracts);
            }
            catch(Exception ex)
            {
                return BadRequest("Erro ao realizar a consulta: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contract> GetById(int id)
        {
            try
            {
                var contract = _contractRepository.GetById(id);

                if (contract == null)
                {
                    return NotFound("Nenhum contrato com esse ID foi encontrado");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao realizar a consulta: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contract> Create(Contract contract)
        {
            try
            {
                _contractRepository.Create(contract);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao realizar a criação: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contract> Update(int id, Contract contract)
        {
            try
            {
                var currentContract = _contractRepository.GetById(id);

                if (currentContract == null)
                {
                    return NotFound("Nenhum contrato com esse ID foi encontrado");
                }

                _contractRepository.Update(id, contract);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao realizar a atualização: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Contract> Delete(int id)
        {
            try
            {
                var currentContract = _contractRepository.GetById(id);

                if (currentContract == null)
                {
                    return NotFound("Nenhum contrato com esse ID foi encontrado");
                }

                var contract = _contractRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao realizar a exclusão: " + ex.Message);
            }
        }
    }
}
