using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace QuoteBot.Dialogs
{
    [Serializable]
    public class BranchLocatorDialog : IDialog<object>
    {
        private string postcode;

        public async Task StartAsync(IDialogContext context)
        {
            if (context.UserData.TryGetValue<string>("postcode", out postcode))
            {
                await SendNearestBranch(context, postcode);
            }
            else
            {
                await context.PostAsync("Please enter your postcode");
                context.Wait(PostcodeEnteredAsync);
            }
        }

        public async Task PostcodeEnteredAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            context.UserData.SetValue<string>("postcode", message.Text);
            await SendNearestBranch(context, message.Text);
        }

        private static async Task SendNearestBranch(IDialogContext context, string postcode)
        {
            await context.PostAsync(string.Format("Your nearest branch is at {0}", "https://www.swinton.co.uk/branch-finder/?location=" +postcode.Replace(" ", "")));
            context.Done<object>(new object());
        }

    }
}