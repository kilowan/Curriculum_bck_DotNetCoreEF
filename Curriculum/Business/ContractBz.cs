using curriculum.Data;
using curriculum.Models;
using System;

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

        public bool UpdateContract(ContractDto contract, int contractId)
        {
            try
            {
                return contractData.UpdateContract(contract, contractId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteContract(int contractId)
        {
            try
            {
                return contractData.DeleteContract(contractId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
