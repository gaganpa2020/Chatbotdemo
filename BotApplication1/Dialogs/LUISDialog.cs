using BotApplication1.Forms;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;

namespace BotApplication1.Dialogs
{
	[LuisModel("bade20ed-f234-4ca4-bb9c-64beb47edee7", "970da8c35021464e8ca1760143fa73c2")]
	[Serializable]
	public class LUISDialogBasic : LuisDialog<object>
	{
		[LuisIntent("Greeting")]
		public async Task Greeting(IDialogContext context, LuisResult result)
		{
			var queryString = result.Query;
			context.Call(new GreetingDialogLuis(queryString), someCallback);
		}

		[LuisIntent("FlightSearch")]
		public async Task FlightSearch(IDialogContext context, LuisResult result)
		{
			var queryString = result.Query;

			var flightSearchDialog = new FormDialog<FlightSearchForm>(new FlightSearchForm(),
				FlightSearchForm.Create, FormOptions.PromptInStart);
			context.Call(flightSearchDialog, someCallback);
		}

		private async Task someCallback(IDialogContext context, IAwaitable<object> result)
		{
			context.Wait(MessageReceived);
		}
	}
}