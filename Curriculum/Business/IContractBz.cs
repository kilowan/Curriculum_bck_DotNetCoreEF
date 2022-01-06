using curriculum.Models;

namespace curriculum.Business
{
    public interface IContractBz
    {
        public bool AddContract(ContractDto contract);
        public bool UpdateContract(ContractDto contract, int contractId);
        public bool DeleteContract(int contractId);
    }
}
