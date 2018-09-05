namespace BotApplication1.DAC
{
	public class Flight
	{
		public string Airline_Name { get; internal set; }
		public string ID { get; internal set; }
		public int Price { get; internal set; }
		public object Departue_City { get; internal set; }
		public object Arrival_City { get; internal set; }
		public object Arrival_City_Code { get; internal set; }
		public object Departue_City_Code { get; internal set; }
		public object Arrival_Time { get; internal set; }
		public object Departure_Time { get; internal set; }
		public object Ticket_Type { get; internal set; }
	}
}