using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    class TaxRateCRUD : CRUD
    {
        public TaxRateCRUD(OleDbConnection connection) : base(connection, "TaxRates")
        {
        }

        public bool insert(DTO.TaxRateDTO taxRate)
        {
            string insertSQL = "Insert Into " + Table + " (id, rate) Values (?)";

            var command = new OleDbCommand(insertSQL, Connection);

            command.Parameters.Add(new OleDbParameter("id", taxRate.Guid.ToString()));
            command.Parameters.Add(new OleDbParameter("rate", taxRate.Rate));

            int i = command.ExecuteNonQuery();

            return i > 0;
        }
    }
}
