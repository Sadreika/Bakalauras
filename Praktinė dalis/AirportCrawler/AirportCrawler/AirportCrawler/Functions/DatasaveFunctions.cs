namespace AirportCrawler.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    class DatasaveFunctions
    {
        public string ConnectionString { get; set; }
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
        public bool TryCreateTable(string tableName, List<string> sqlColumnCodes)
        {
            try
            {
                Command.CommandText = $"CREATE TABLE {tableName} \u0028";

                for(int i = 0; i < sqlColumnCodes.Count; i++)
                {
                    if(i - 1 == sqlColumnCodes.Count)
                    {
                        Command.CommandText += sqlColumnCodes[i] + "\u0029";
                    }
                    else
                    {
                        Command.CommandText += sqlColumnCodes[i] + ", ";
                    }
                }

                Command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TryRemoveTable(string tableName)
        {
            try
            {
                Command.CommandText = $"DROP TABLE {tableName}";
                Command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TryFillTableWithData(string tableName, List<string> columnNames)
        {
            try
            {
                Command.CommandText = $"INSERT INTO {tableName} \u0028";

                for (int i = 0; i < columnNames.Count; i++)
                {
                    if (i - 1 == columnNames.Count)
                    {
                        Command.CommandText += columnNames[i] + "\u0029 ";
                    }
                    else
                    {
                        Command.CommandText += columnNames[i] + ", ";
                    }
                }

                //Command.CommandText +=

                //"VALUES (1001, 'Puneet Nehra', 'A 449 Sect 19, DELHI', 23.98 ) ";

                //REIKIA SUKURTI METODA KURIS LISTO DUOMENIS PAVERSTU I SQL CODA TOKIO FORMATO (..., ..., ..., ...)

                Command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
