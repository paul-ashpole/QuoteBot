using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace QuoteBot.Dialogs
{
    [Serializable]
    public class BranchLocatorDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Please enter your postcode");
            context.Wait(PostcodeEnteredAsync);
        }

        public async Task PostcodeEnteredAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await context.PostAsync(string.Format("Your nearest branch is at {0}", "https://www.swinton.co.uk/branch-finder/?location=" + message.Text.Replace(" ","")));
            context.Done<object>(new object());
        }
    }
}