using curriculum.Models;
using System;
using System.Linq;

namespace curriculum.Data
{
    public class ContractData : IContractData
    {
        private readonly CurriculumContext _context;
        public ContractData(CurriculumContext context)
        {
            _context = context;
        }

        public bool AddContract(ContractDto contract)
        {
            try
            {
                bool result = false;
                int lastId = _context.Contracts
                    .OrderBy(exp => exp.id)
                    .Select(exp => exp.id)
                    .LastOrDefault() + 1;

                _context.Contracts.Add(new Models.Contract()
                {
                    id = lastId,
                    name = contract.contractName,
                    experienceId = contract.experienceId
                });

                if (_context.SaveChanges() == 1) result = true;

                return result;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
