namespace AirlinesDbTablesCreator
{
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            string tableName = args[0].ToString();
            DatasaveFunctions Datasave = new DatasaveFunctions();
            Datasave.Connection.Open();

            List<string> sqlColumnCodes = new List<string>()
            {
                { "Id int IDENTITY(1,1) NOT NULL PRIMARY KEY" },

                { "OriginOutbound nvarchar(5) NOT NULL" },
                { "DestinationOutbound nvarchar(5) NOT NULL" },
                { "ConnectionOutbound nvarchar(5)" },

                { "PriceWithoutTaxesOutbound decimal(10,2) NOT NULL" },
                { "FullPriceOutbound decimal(10,2)" },
                { "TaxesOutbound decimal(10,2)" },

                { "DepartureTimeOutbound datetime NOT NULL"},
                { "ArrivalTimeOutbound datetime NOT NULL"},

                { "TravelDurationOutbound nvarchar(50) NOT NULL"},

                { "OriginInbound nvarchar(5) NOT NULL" },
                { "DestinationInbound nvarchar(5) NOT NULL" },
                { "ConnectionInbound nvarchar(5)" },

                { "PriceWithoutTaxesInbound decimal(10,2) NOT NULL" },
                { "FullPriceInbound decimal(10,2)" },
                { "TaxesInbound decimal(10,2)" },

                { "DepartureTimeInbound datetime NOT NULL"},
                { "ArrivalTimeInbound datetime NOT NULL"},

                { "TravelDurationInbound nvarchar(50) NOT NULL"},

                { "PriceWithoutTaxes decimal(10,2) NOT NULL" },
                { "FullPrice decimal(10,2)" },
                { "Taxes decimal(10,2)" },

                { "Currency nvarchar(5) NOT NULL"},
                {"FareFamily nvarchar(50)" },
                {"FlightNumber nvarchar(50) NOT NULL" },
                {"Class nchar(2) NOT NULL" },
                {"Airlines nvarchar(50) NOT NULL" }

            };

            Datasave.TryCreateTable(tableName, sqlColumnCodes);

            Datasave.Connection.Close();
        }
    }
}
