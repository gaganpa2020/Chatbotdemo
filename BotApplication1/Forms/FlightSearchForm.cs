using Microsoft.Bot.Builder.FormFlow;
using System;

namespace BotApplication1.Forms
{
	public enum FlighType
	{
		NonStop = 1,
		SingleStop,
		MultipleStops
	}

	public enum MealOptions
	{
		Veg = 1,
		NonVeg
	}

	[Serializable]
	public class FlightSearchForm
	{
		public string FlightSource { get; set; }
		public string FlightDestination { get; set; }
		public DateTime TravelDate { get; set; }
		public FlighType FlightType { get; set; }
		public MealOptions MealOption { get; set; }

		public static IForm<FlightSearchForm> Create()
		{
			return new FormBuilder<FlightSearchForm>()
				.Message("building flight search form")
				.Field(nameof(FlightSource))
				.Field(nameof(FlightDestination),
					validate: async (state, value) =>
					{
						ValidateResult result = new ValidateResult()
						{
							IsValid = true,
							Value = value
						};
						if (state.FlightSource.Equals(Convert.ToString(value), StringComparison.InvariantCultureIgnoreCase))
						{
							result.IsValid = false;
							result.Feedback = "Source & Destination can't be same";
						}

						return result;
					}
				)
				.AddRemainingFields()
				.Build();
		}
	}
}