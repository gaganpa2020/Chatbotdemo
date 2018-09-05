using BotApplication1.Forms;
using System;
using System.Collections.Generic;

namespace BotApplication1.DAC
{
	public static class FlightManager
    {
        public static IEnumerable<Flight> Flights(FlightSearchForm searchQuery)
        {
            var flights = new List<Flight>();
            var random = new Random();

            //filling data manually for demo purpose
            for (int i = 0; i < random.Next(2, 5); i++)
            {
                Flight flight = new Flight()
                {
                    Airline_Name = i % 2 == 0 ? "Jet Airways" : "Emirates",
                    ID = random.Next(300, 700).ToString(),
                    Price = random.Next(400, 700),
                    Departue_City = searchQuery.FlightSource,
                    Arrival_City = searchQuery.FlightDestination,
                    Arrival_City_Code = searchQuery.FlightDestination.Substring(0, 3).ToUpper(),
                    Departue_City_Code = searchQuery.FlightSource.Substring(0, 3).ToUpper(),
                    Arrival_Time = searchQuery.TravelDate.AddHours(random.Next(4, 10)),
                    Departure_Time = searchQuery.TravelDate.AddHours(-(random.Next(0, 3)))//,
                    //Ticket_Type = searchQuery.TicketType.ToString()
                };

                flights.Add(flight);
            }


            return flights;
        }
    }
}