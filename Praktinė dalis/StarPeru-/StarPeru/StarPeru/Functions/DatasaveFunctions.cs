namespace Functions.StarPeru
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    class DatasaveFunctions
    {
        //public string ConnectionString { get; set; }
        //public SqlConnection Connection { get; set; }
        //public SqlCommand Command { get; set; }
        //public DatasaveFunctions(string connectionString)
        //{
        //    ConnectionString = connectionString;
        //    Connection = new SqlConnection(ConnectionString);
        //    Command = new SqlCommand();
        //    Command.CommandType = CommandType.Text;
        //    Command.Connection = Connection;
        //}
        //public void RenewConnection(string connectionString)
        //{
        //    ConnectionString = connectionString;
        //    Connection = new SqlConnection(ConnectionString);
        //}
        //public void RenewCommand()
        //{
        //    Command = new SqlCommand();
        //    Command.CommandType = CommandType.Text;
        //    Command.Connection = Connection;
        //}
        //public void StartConnection()
        //{
        //    Connection.Open();
        //}
        //public void EndConnection()
        //{
        //    Connection.Close();
        //}
        //public bool TryCreateTable(string tableName, List<string> sqlColumnCodes)
        //{
        //    try
        //    {
        //        Command.CommandText = $"CREATE TABLE {tableName} \u0028";

        //        AddSqlColumns(sqlColumnCodes);

        //        Command.ExecuteNonQuery();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool TryRemoveTable(string tableName)
        //{
        //    try
        //    {
        //        Command.CommandText = $"DROP TABLE {tableName}";
        //        Command.ExecuteNonQuery();

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        ////public bool TryFillTableWithData(string tableName, List<string> columnNames, List<CurrencyInfo> dataList)
        ////{
        ////    try
        ////    {
        ////        foreach (CurrencyInfo data in dataList)
        ////        {
        ////            Command.CommandText = $"INSERT INTO {tableName} \u0028";

        ////            AddSqlColumns(columnNames);

        ////            Command.CommandText += " VALUES \u0028";

        ////            AddSqlValues(data);

        ////            Command.ExecuteNonQuery();
        ////        }

        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}
        ////public void AddSqlColumns(List<string> valuesToAdd)
        ////{
        ////    for (int i = 0; i < valuesToAdd.Count; i++)
        ////    {
        ////        if (i == valuesToAdd.Count - 1)
        ////        {
        ////            Command.CommandText += valuesToAdd[i].Trim() + "\u0029";
        ////        }
        ////        else
        ////        {
        ////            Command.CommandText += valuesToAdd[i].Trim() + ", ";
        ////        }
        ////    }
        ////}
        ////public void AddSqlValues(CurrencyInfo valuesToAdd)
        ////{
        ////    Command.CommandText += $"'{valuesToAdd.Search.Trim().Replace("'", "")}', '{valuesToAdd.Value.Trim().Replace("'", "")}', '{valuesToAdd.Display.Trim().Replace("'", "")}' \u0029";
        ////}
    }
}
