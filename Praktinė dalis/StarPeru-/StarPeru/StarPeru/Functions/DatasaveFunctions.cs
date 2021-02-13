namespace StarPeru.Functions
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    class DatasaveFunctions
    {
        private string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True";
        private SqlConnection Connection { get; set; }
        private SqlCommand Command { get; set; }
        public DatasaveFunctions()
        {
            Connection = new SqlConnection(ConnectionString);
            Command = new SqlCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
        }
        private void RenewCommand()
        {
            Command = new SqlCommand();
            Command.CommandType = CommandType.Text;
            Command.Connection = Connection;
        }

        public bool TryFillTableWithData(string tableName, List<string> columnNames /*List<CurrencyInfo> dataList*/)
        {
            try
            {
                //foreach (CurrencyInfo data in dataList)
                //{
                //    Command.CommandText = $"INSERT INTO {tableName} \u0028";

                //    AddSqlColumns(columnNames);

                //    Command.CommandText += " VALUES \u0028";

                //    AddSqlValues(data);

                //    Command.ExecuteNonQuery();
                //}

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
        public void AddSqlValues()
        {
            //Command.CommandText += $"'{valuesToAdd.Search.Trim().Replace("'", "")}', '{valuesToAdd.Value.Trim().Replace("'", "")}', '{valuesToAdd.Display.Trim().Replace("'", "")}' \u0029";
        }

        public bool TryToSaveFlights(List<Combinations> combinations)
        {
            Connection.Open();


            Connection.Close();
            return false;
        }
    }
}
