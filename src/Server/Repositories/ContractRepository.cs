using System.Data;
using System.Data.SqlClient;
using Server.Models;
using Server.Properties;

namespace Server.Repositories;

public class ContractRepository : IRepository<Contract>
{
    private IDbConnection? _con;

    public List<Contract> Items {
        get
        {
            using (_con = new SqlConnection(Resources.ConnectionString))
            {
                _con.Open();
                
                var cmd = new SqlCommand(Resources.SelectContracts, _con as SqlConnection);

                var contracts = new List<Contract>();

                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var contract = new Contract
                    {
                        Id = (int)rdr[nameof(Contract.Id)],
                        CreatedOn = (DateTime)rdr[nameof(Contract.CreatedOn)],
                        Index = (int)rdr[nameof(Contract.Index)],
                        UpdatedOn = (DateTime)rdr[nameof(Contract.UpdatedOn)],
                    };

                    contracts.Add(contract);
                }

                return contracts;
            }
        }
    }

    public Contract? Get(int id) =>
        Items.Find(c => c.Id == id);

    public void Add(Contract item)
    {
        throw new NotImplementedException();
    }

    public void Update(Contract updatedItem, int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }
}