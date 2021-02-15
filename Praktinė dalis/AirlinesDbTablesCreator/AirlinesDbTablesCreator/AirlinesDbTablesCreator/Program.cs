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

                {"FareFamilyOutbound nvarchar(50)" },
                {"FlightNumberOutbound nvarchar(50) NOT NULL" },

                { "OriginInbound nvarchar(5)" },
                { "DestinationInbound nvarchar(5)" },
                { "ConnectionInbound nvarchar(5)" },

                { "PriceWithoutTaxesInbound decimal(10,2)" },
                { "FullPriceInbound decimal(10,2)" },
                { "TaxesInbound decimal(10,2)" },

                { "DepartureTimeInbound datetime"},
                { "ArrivalTimeInbound datetime"},

                { "TravelDurationInbound nvarchar(50)"},

                {"FareFamilyInbound nvarchar(50)" },
                {"FlightNumberInbound nvarchar(50)" },

                { "PriceWithoutTaxes decimal(10,2) NOT NULL" },
                { "FullPrice decimal(10,2)" },
                { "Taxes decimal(10,2)" },

                { "Currency nvarchar(5) NOT NULL"},
               
                {"Class nchar(2) NOT NULL" },
                {"Airlines nvarchar(50) NOT NULL" }

            };

            Datasave.TryCreateTable(tableName, sqlColumnCodes);

            Datasave.Connection.Close();
        }
    }
}
