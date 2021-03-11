namespace Flights_Recommendation_System_GUI.Functions
{
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
        public void StartConnection()
        {
            Connection.Open();
        }
        public void EndConnection()
        {
            Connection.Close();
        }
        public bool TryFillTableWithData(string tableName, List<string> columnNames, List<string> dataList)
        {
            try
            {
                Command.CommandText = $"INSERT INTO {tableName} \u0028";

                AddSqlColumns(columnNames);

                Command.CommandText += " VALUES \u0028";

                AddSqlValues(dataList);

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
        public void AddSqlValues(List<string> valuesToAdd)
        {
            for (int i = 0; i < valuesToAdd.Count; i++)
            {
                if (i == valuesToAdd.Count - 1)
                {
                    Command.CommandText += "'" + valuesToAdd[i].Trim() + "'" + "\u0029";
                }
                else
                {
                    Command.CommandText += "'" + valuesToAdd[i].Trim() + "'" + ", ";
                }
            }
        }
        public bool TryGetDataFromTable(string tableName, string selectionString, out DataTable dataFromDatabase)
        {
            dataFromDatabase = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT {selectionString} FROM {tableName}", Connection);
                sqlDataAdapter.Fill(dataFromDatabase);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TryGetDataFromTableCustom(string query, out DataTable dataFromDatabase)
        {
            dataFromDatabase = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Connection);
                sqlDataAdapter.Fill(dataFromDatabase);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public string ConstructSelectionString(string airlineText, string departureAirportText, string arrivalAirportText,
            string departureDateTimePickerText, string arrivalDateTimePickerText, bool owrtCheck, string classComboBoxText,
            string lowestPriceTextBox, string biggestPriceTextBox, string hoursNumericUpDown,
            string minutesNumericUpDown, bool zeroStopsCheckBox, bool oneStopCheckBox, bool isSearch)
        {
            string[] departureDateParts = departureDateTimePickerText.Split('-');
            string[] arrivalDateParts = arrivalDateTimePickerText.Split('-');

            string query = string.Empty;

            query += $"SELECT * fROM {airlineText} WHERE ";

            if (isSearch)
            {
                query += $"DATEPART(yyyy, DepartureTimeOutbound) = {departureDateParts[0]} ";
                query += $"AND DATEPART(MM, DepartureTimeOutbound) = {departureDateParts[1]} " +
                         $"AND DATEPART(dd, DepartureTimeOutbound) = {departureDateParts[2]} ";

                if (owrtCheck)
                {
                    query += $"AND DATEPART(yyyy, ArrivalTimeInbound) = {arrivalDateParts[0]} " +
                             $"AND DATEPART(MM, ArrivalTimeInbound) = {arrivalDateParts[1]} " +
                             $"AND DATEPART(dd, ArrivalTimeInbound) = {arrivalDateParts[2]} ";
                }
                else
                {
                    query += "AND ArrivalTimeInbound IS NULL ";
                }
            }

            if (!isSearch)
            {
                query += $"OriginOutbound = '{departureAirportText}' ";
                query += $"AND DestinationOutbound = '{arrivalAirportText}' ";
            }
            else
            {
                if (departureAirportText != string.Empty)
                {
                    query += $"AND OriginOutbound = '{departureAirportText}' ";
                }

                if (arrivalAirportText != string.Empty)
                {
                    query += $"AND DestinationOutbound = '{arrivalAirportText}' ";
                }
            }

            query += $"AND Class = '{Dictionary.TravelClassesDictionary[classComboBoxText]}' ";

            if (lowestPriceTextBox != string.Empty)
            {
                query += $"AND FullPrice > {lowestPriceTextBox} ";
            }

            if (biggestPriceTextBox != string.Empty)
            {
                query += $"AND FullPrice < {biggestPriceTextBox} ";
            }

            if (hoursNumericUpDown != "0" || minutesNumericUpDown != "0")
            {
                string dateTime = string.Empty;
  
                if (int.Parse(hoursNumericUpDown) > 9)
                {
                    dateTime += $"{hoursNumericUpDown}:";
                }
                else
                {
                    dateTime += $"0{hoursNumericUpDown}:";
                }

                if(int.Parse(minutesNumericUpDown) > 9)
                {
                    dateTime += $"{minutesNumericUpDown}:00";
                }
                else
                {
                    dateTime += $"0{minutesNumericUpDown}:00";
                }

                query += $"AND TravelDurationOutbound < '{dateTime}' ";

                if (owrtCheck)
                {
                    query += $"AND TravelDurationInbound < '{dateTime}' ";
                }
            }

            if(zeroStopsCheckBox != true || oneStopCheckBox != true)
            {
                if (zeroStopsCheckBox)
                {
                    query += "AND ConnectionOutbound = 'null' ";

                    if (owrtCheck)
                    {
                        query += "AND ConnectionInbound = 'null' ";
                    }
                }

                if (oneStopCheckBox)
                {
                    query += "AND ConnectionOutbound != 'null' ";

                    if (owrtCheck)
                    {
                        query += "AND ConnectionInbound != 'null' ";
                    }
                }
            }

            return query;
        }
    }
}
