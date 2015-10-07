using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    abstract public class CRUD
    {
        public OleDbConnection Connection { get; private set; }

        private string table;

        public string Table
        {
            get { return table; }
            set { table = value.ToLower(); }
        }
        

        public CRUD(OleDbConnection connection, string table)
        {
            Connection = connection;
            Table = table;
        }

    }
}
