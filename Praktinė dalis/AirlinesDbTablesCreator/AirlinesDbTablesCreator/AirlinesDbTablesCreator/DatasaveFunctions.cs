namespace AirlinesDbTablesCreator
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    class DatasaveFunctions
    {
        public string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True";
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public DatasaveFunctions()
        {
            Connection = new SqlConnection(ConnectionString);
            Command = new SqlCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
        }
        public bool TryCreateTable(string tableName, List<string> sqlColumnCodes)
        {
            try
            {
                Command.CommandText = $"CREATE TABLE {tableName} \u0028";

                AddSqlColumns(sqlColumnCodes);

                Command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void AddSqlColumns(List<string> valuesToAdd)
        {
            for (int i = 0; i < valuesToAdd.Count; i++)
            {
                if (i == valuesToAdd.Count - 1)
                {
                    Command.CommandText += valuesToAdd[i].Trim() + "\u0029";
                }
                else
                {
                    Command.CommandText += valuesToAdd[i].Trim() + ", ";
                }
            }
        }
    }
}
