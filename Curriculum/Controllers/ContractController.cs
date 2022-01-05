using curriculum.Business;
using curriculum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace curriculum.Controllers
{
    [Route("api/Contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractBz contractBz;
        public ContractController(IContractBz contractBz)
        {
            this.contractBz = contractBz;
        }

        [HttpPost]
        [Authorize]
        public bool AddContract(ContractDto contract)
        {
            try
            {
                return contractBz.AddContract(contract);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPut("{contractId}")]
        [Authorize]
        public bool UpdateContract(ContractDto contract, int contractId)
        {
            try
            {
                return contractBz.UpdateContract(contract, contractId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
