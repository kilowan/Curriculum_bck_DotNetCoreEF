using curriculum.Data;
using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Business
{
    public class ContractBz : IContractBz
    {
        public readonly IContractData contractData;
        public ContractBz(IContractData contractData)
        {
            this.contractData = contractData;
        }

        public bool AddContract(ContractDto contract) 
        {
            try
            {
                return contractData.AddContract(contract);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
