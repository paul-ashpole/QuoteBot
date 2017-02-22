using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using QuoteBot.Models;
using System;
using System.Threading.Tasks;

namespace QuoteBot.Dialogs
{
    [Serializable]
    public class ChooseDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Welcome to the Swinton website. How can we help you today?");
            context.Wait(ConversationStartedAsync);            
        }

        private async Task ConversationStartedAsync(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(ChoiceMadeAsync);
        }

        private async Task ChoiceMadeAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text.Contains("claim"))
            {
                context.Call(new ClaimsDialog(), DialogCompletedAsync);
            }
            else if (message.Text.Contains("branch"))
            {
                context.Call(new BranchLocatorDialog(), DialogCompletedAsync);
            }
            else if (message.Text.Contains("quote"))
            {
                context.Call(FormDialog.FromForm(RiskData.BuildForm,options: FormOptions.PromptInStart), RiskCaptureDialogCompletedAsync);
            }
            else if (message.Text.Contains("no"))
            {
                await context.PostAsync("Thanks for chatting!");
                context.Wait(ChoiceMadeAsync);
            }
            else
            {
                await context.PostAsync("Sorry I don't understand what you want to do. Can you rephrase your request");
                context.Wait(ChoiceMadeAsync);
            }

        }

        private async Task RiskCaptureDialogCompletedAsync(IDialogContext context, IAwaitable<RiskData> result)
        {
            await context.PostAsync("Thank you for supplying your information. We're searching for our best price");
            context.Call(new QuoteDialog(), DialogCompletedAsync);
        }

        private async Task DialogCompletedAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Is there anything else we can help you with today?");
            context.Wait(ChoiceMadeAsync);
        }
    }
}