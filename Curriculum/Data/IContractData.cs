using curriculum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curriculum.Data
{
    public interface IContractData
    {
        public bool AddContract(ContractDto contract);
        public bool UpdateContract(ContractDto contract, int contractId);
        public bool DeleteContract(int contractId);
    }
}
