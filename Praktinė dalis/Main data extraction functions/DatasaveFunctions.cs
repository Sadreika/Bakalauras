namespace MainDataExtractionFunctions
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    class DatasaveFunctions
    {
        public static string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public DatasaveFunctions(string connectionString)
        {
            ConnectionString = connectionString;
            Connection = new SqlConnection(ConnectionString);
            Command = new SqlCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
        }
        public void RenewConnection(string connectionString)
        {
            ConnectionString = connectionString;
            Connection = new SqlConnection(ConnectionString);
        }
        public void RenewCommand()
        {
            Command = new SqlCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
        }
        public void StartConnection()
        {
            Connection.Open();
        }
        public void EndConnection()
        {
            Connection.Close();
        }
        public bool TryCreateTable()
        {
          
            return false;
        }

        public bool TryRemoveTable()
        {
            return false;
        }

        public bool TryFillTableWithData()
        {
            return false;
        }
    }
}
