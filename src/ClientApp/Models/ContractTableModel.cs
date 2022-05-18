using System;
using ContractsModel;

namespace ClientApp.Models
{
    public class ContractTableModel
    {
        private readonly Contract _contract;

        public ContractTableModel(Contract contract)
        {
            _contract = contract;
        }

        public int Id => _contract.Id;

        public string Index => _contract.Index;

        public string CreatedOn => _contract.CreatedOn?.ToString("d MMMM yyyy");

        public string UpdatedOn => _contract.UpdatedOn?.ToString("d MMMM yyyy");

        public bool IsValid =>
            (DateTime.UtcNow - _contract.UpdatedOn)?.Days < 30;
    }
}