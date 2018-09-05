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
	public class FlightSearchDialog : IDialog
	{
		public async Task StartAsync(IDialogContext context)
		{
			var form = FormDialog.FromForm<FlightSearchForm>(FlightSearchForm.Create
				, FormOptions.PromptInStart);
			context.Call(form, MessageReceivedAsync);
		}

		private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
		{
			var activity = await result as Activity;
			await context.PostAsync($"We have 10 flights");
			//context.Wait(MessageReceivedAsync);
			context.Done<string>("Flight serach is done.");
		}
	}
}