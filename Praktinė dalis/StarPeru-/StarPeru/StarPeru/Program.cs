namespace StarPeru
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    public class Program
    {
        //private static string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsDatabase;Integrated Security=True";
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            bool isDataCollected = crawler.Start("LIM|HUU|2021|03|19|2021|03|26|E|R|XXX|2");
            //FillDatabase(flights);
        }

        //public static void StartStarPeruFromGUI(string searchCriteria)
        //{
        //    Crawler crawler = new Crawler();
        //    List<Combinations> flights = crawler.Start(searchCriteria);
        //    FillDatabase(flights);
        //}
        //public static void FillDatabase(List<Combinations> combinations)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    foreach (Combinations combination in combinations)
        //    {
        //        SqlCommand command = new SqlCommand();
        //        command.CommandType = CommandType.Text;
        //        command.Connection = con;
        //        con.Open();
        //        command.Parameters.AddWithValue("@OriginOutbound", combination.Outbound.Origin.Trim());
        //        command.Parameters.AddWithValue("@DestinationOutbound", combination.Outbound.Destination.Trim());
        //        command.Parameters.AddWithValue("@ConnectionOutbound", "nėra");
        //        command.Parameters.AddWithValue("@PriceOutbound", combination.Outbound.Price);
        //        command.Parameters.AddWithValue("@DepartureTimeOutbound", combination.Outbound.DepartureTime);
        //        command.Parameters.AddWithValue("@ArrivalTimeOutbound", combination.Outbound.ArrivalTime);
        //        command.Parameters.AddWithValue("@TravelTimeOutbound", (combination.Outbound.ArrivalTime.Subtract(combination.Outbound.DepartureTime)).ToString());

        //        if (combination.Inbound != null)
        //        {
        //            command.Parameters.AddWithValue("@OriginInbound", combination.Inbound.Origin.Trim());
        //            command.Parameters.AddWithValue("@DestinationInbound", combination.Inbound.Destination.Trim());
        //            command.Parameters.AddWithValue("@ConnectionInbound", "nėra");
        //            command.Parameters.AddWithValue("@PriceInbound", combination.Inbound.Price);
        //            command.Parameters.AddWithValue("@DepartureTimeInbound", combination.Inbound.DepartureTime);
        //            command.Parameters.AddWithValue("@ArrivalTimeInbound", combination.Inbound.ArrivalTime);
        //            command.Parameters.AddWithValue("@TravelTimeInbound", (combination.Outbound.ArrivalTime.Subtract(combination.Outbound.DepartureTime)).ToString());
        //        }

        //        if (combination.Inbound != null)
        //        {
        //            command.Parameters.AddWithValue("@TotalPrice", combination.Outbound.Price + combination.Inbound.Price);
        //        }
        //        else
        //        {
        //            command.Parameters.AddWithValue("@TotalPrice", combination.Outbound.Price);
        //        }

        //        command.Parameters.AddWithValue("@Class", "E");
        //        command.Parameters.AddWithValue("@Airline", "StarPeru");

        //        if (combination.Inbound != null)
        //        {
        //            command.CommandText = "INSERT [FlightsDatabase].[dbo].[StarPeru] (OriginOutbound, DestinationOutbound, ConnectionOutbound," +
        //                "PriceOutbound, DepartureTimeOutbound, ArrivalTimeOutbound, TravelTimeOutbound," +
        //                "OriginInbound, DestinationInbound, ConnectionInbound," +
        //                "PriceInbound, DepartureTimeInbound, ArrivalTimeInbound, TravelTimeInbound," +
        //                "Class, Airline, TotalPrice)" +
        //                "VALUES (@OriginOutbound, @DestinationOutbound, @ConnectionOutbound, @PriceOutbound, @DepartureTimeOutbound," +
        //                "@ArrivalTimeOutbound, @TravelTimeOutbound, @OriginInbound, @DestinationInbound, @ConnectionInbound, @PriceInbound, @DepartureTimeInbound," +
        //                "@ArrivalTimeInbound, @TravelTimeInbound, @Class, @Airline, @TotalPrice)";
        //        }
        //        else
        //        {
        //            command.CommandText = "INSERT [FlightsDatabase].[dbo].[StarPeru] (OriginOutbound, DestinationOutbound, ConnectionOutbound," +
        //                "PriceOutbound, DepartureTimeOutbound, ArrivalTimeOutbound, TravelTimeOutbound," +
        //                "Class, Airline, TotalPrice)" +
        //                "VALUES (@OriginOutbound, @DestinationOutbound, @ConnectionOutbound, @PriceOutbound, @DepartureTimeOutbound," +
        //                "@ArrivalTimeOutbound, @TravelTimeOutbound, @Class, @Airline, @TotalPrice)";
        //        }

        //        command.ExecuteNonQuery();
        //        con.Close();
        //    }
       // }
    }
}
