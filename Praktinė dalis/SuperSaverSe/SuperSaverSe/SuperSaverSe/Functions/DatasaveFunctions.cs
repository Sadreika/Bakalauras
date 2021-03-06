namespace SuperSaverSe.Functions
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
        public bool TryFillTableWithData(List<Combinations> combinations)
        {
            string tableName = "SuperSaverSe";
            List<string> columnNames = new List<string>()
            {
                {"OriginOutbound"},
                {"DestinationOutbound"},
                {"ConnectionOutbound"},
                {"PriceWithoutTaxesOutbound"},
                {"FullPriceOutbound"},
                {"TaxesOutbound"},
                {"DepartureTimeOutbound"},
                {"ArrivalTimeOutbound"},
                {"TravelDurationOutbound"},
                {"FareFamilyOutbound"},
                {"FlightNumberOutbound"},
                {"OriginInbound"},
                {"DestinationInbound"},
                {"ConnectionInbound"},
                {"PriceWithoutTaxesInbound"},
                {"FullPriceInbound"},
                {"TaxesInbound"},
                {"DepartureTimeInbound"},
                {"ArrivalTimeInbound"},
                {"TravelDurationInbound"},
                {"FareFamilyInbound"},
                {"FlightNumberInbound"},
                {"PriceWithoutTaxes"},
                {"FullPrice"},
                {"Taxes"},
                {"Currency"},
                {"Class"},
                {"Airlines"},
            };

            try
            {
                Connection.Open();

                foreach (Combinations combination in combinations)
                {
                    Command.CommandText = $"INSERT INTO {tableName} \u0028";

                    AddSqlColumns(columnNames);

                    Command.CommandText += " VALUES \u0028";

                    AddSqlValues(combination);

                    Command.ExecuteNonQuery();
                }

                Connection.Close();
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
        public void AddSqlValues(Combinations combination)
        {
            Command.CommandText += $"'{combination.Outbound.Origin}', " +
               $"'{combination.Outbound.Destination}', " +
               $"'{combination.Outbound.Connection}', " +
               $"'', " +
               $"'', " +
               $"'', " +
               $"'{combination.Outbound.DepartureTime}', " +
               $"'{combination.Outbound.ArrivalTime}', " +
               $"'{combination.Outbound.TravelDuration}', " +
               $"'', " +
               $"'{combination.Outbound.FlightNumber}', ";

            if (combination.Inbound != null)
            {
                Command.CommandText += $"'{combination.Inbound.Origin}', " +
                $"'{combination.Inbound.Destination}', " +
                $"'{combination.Inbound.Connection}', " +
                $"'', " +
                $"'', " +
                $"'', " +
                $"'{combination.Inbound.DepartureTime}', " +
                $"'{combination.Inbound.ArrivalTime}', " +
                $"'{combination.Inbound.TravelDuration}', " +
                $"'', " +
                $"'{combination.Inbound.FlightNumber}', ";
            }
            else
            {
                Command.CommandText +=
                $"'', '', '', '', '', '', '', '', '', '', '', ";
            }

            Command.CommandText += $"{combination.PriceWithoutTaxes}, " +
                $"{combination.FullPrice}, " +
                $"{combination.Taxes}, " +

                $"'{combination.Currency}', " +
                $"'{combination.Outbound.Class}', " +
                $"'{combination.Outbound.Airline}' \u0029";

            Command.CommandText = Command.CommandText.Replace("''", "null");
        }
    }
}
