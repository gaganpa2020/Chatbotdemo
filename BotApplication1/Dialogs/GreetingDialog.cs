using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotApplication1.Dialogs
{
	[Serializable]
	public class GreetingDialog : IDialog
	{
		public Task StartAsync(IDialogContext context)
		{
			context.Wait(MessageReceivedAsync);
			return Task.CompletedTask;
		}

		private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
		{
			var activity = await result as Activity;
			await context.PostAsync($"this is the greeting dialog, I'm waiting here.");
			context.Wait(MessageReceivedAsync);
			//context.Done<string>("greeting is done");
		}
	}
}