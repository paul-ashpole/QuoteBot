using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using System;

namespace QuoteBot.Dialogs
{
    [Serializable]
    public class ClaimsDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hope you're ok. Please call the Swinton Accident and Claims Line on **0800 040 7019** or click on https://www.swinton.co.uk/car-insurance/contact/claims/");
            context.Done<object>(new object());
        }
    }
}