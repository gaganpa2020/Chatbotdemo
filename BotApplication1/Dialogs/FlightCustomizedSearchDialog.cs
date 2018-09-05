using AdaptiveCards;
using BotApplication1.DAC;
using BotApplication1.Forms;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotApplication1.Dialogs
{
	[Serializable]
	public class FlightCustomizedSearchDialog : IDialog
	{
		public async Task StartAsync(IDialogContext context)
		{
			var form = FormDialog.FromForm<FlightSearchForm>(FlightSearchForm.Create
				, FormOptions.PromptInStart);
			context.Call(form, MessageReceivedAsync);
		}

		private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<FlightSearchForm> result)
		{
			var searchQuery = await result;
			var results = FlightManager.Flights(searchQuery);

			List<Attachment> attachments = new List<Attachment>();

			foreach (var flight in results)
			{
				AdaptiveCard adaptiveCard = new AdaptiveCard();
				adaptiveCard.Body.Add(new TextBlock()
				{
					Text = flight.Airline_Name,
					Size = TextSize.ExtraLarge
				});
				adaptiveCard.Body.Add(new TextBlock()
				{
					Text = $"$:{flight.Price}",
					Size = TextSize.ExtraLarge
				});
				Attachment attachment = new Attachment()
				{
					ContentType = AdaptiveCard.ContentType,
					Content = adaptiveCard
				};
				attachments.Add(attachment);
			}

			var response = context.MakeMessage();
			response.AttachmentLayout = AttachmentLayoutTypes.Carousel;
			response.Attachments = attachments;
			await context.PostAsync(response);
			//context.Wait(MessageReceivedAsync);
			context.Done<object>(null);
		}
	}
}