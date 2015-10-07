﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using ADOX;

namespace Infrastructure.Database
{
    public class Manager
    {
        public OleDbConnection Connection { get; private set; }

        public Manager(OleDbConnection connection)
        {
            Connection = connection;
        }

        public static string CreateNewDatabase(string fileName)
        {
            string result = null;

            try
            {
                var catalog = new ADOX.Catalog();
                var connectionStringBuilder = new OleDbConnectionStringBuilder();

                connectionStringBuilder.ConnectionString = @"Data Source=" + fileName;
                connectionStringBuilder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
                connectionStringBuilder.Add("Jet OLEDB:Engine Type", "5");

                catalog.Create(connectionStringBuilder.ConnectionString);

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(catalog);

                result = connectionStringBuilder.ConnectionString;
            } 
            catch (Exception)
            {
                result = null;
            }
            
            return result;
        }

        public void CreateNewTable(string name, Dictionary<string, string> columns)
        {   
            var tmpList = new List<string>();

            foreach(var pair in columns)
            {
                tmpList.Add("[" + pair.Key + "] " + pair.Value);
            }

            var tmpQueryString = string.Join(",", tmpList.ToArray());
            var queryString = "CREATE TABLE [" + name.ToLower() + "](" + tmpQueryString + ")";
            var tableCreationCmd = new OleDbCommand();

            tableCreationCmd.Connection = Connection;
            tableCreationCmd.CommandText = queryString;
            tableCreationCmd.ExecuteNonQuery();
        
        }

        protected bool TableExists(string tableName)
        {
            var schema = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            return schema.Rows
                .OfType<DataRow>()
                .Any(r => r.ItemArray[2].ToString().ToLower() == tableName.ToLower());
        }

    }
}