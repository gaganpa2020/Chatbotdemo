using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotApplication1.Dialogs
{
	[Serializable]
	public class RootDialog : IDialog<object>
	{
		public Task StartAsync(IDialogContext context)
		{
			context.Wait(MessageReceivedAsync);

			return Task.CompletedTask;
		}

		private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
		{
			var activity = await result as Activity;

			// Calculate something for us to return
			int length = (activity.Text ?? string.Empty).Length;


			var message = activity.Text.ToLower();

			if (message.Contains("hi"))
			{
				await context.Forward(new GreetingDialog(), resumeCallback, activity);
			}
			else if (message.Contains("search"))
			{
				//await context.Forward(new FlightSearchDialog(), somecallback, activity);
				context.Call(new FlightCustomizedSearchDialog(), somecallback);
			}
			else
			{
				// Return our reply to the user
				await context.PostAsync($"You sent {activity.Text} which was {length} characters");
				context.Wait(MessageReceivedAsync);
			}
		}

		private async Task resumeCallback(IDialogContext context, IAwaitable<object> result)
		{
			context.Wait(MessageReceivedAsync);
		}

		private async Task somecallback(IDialogContext context, IAwaitable<object> result)
		{
			 context.Wait(MessageReceivedAsync);
		}
	}
}