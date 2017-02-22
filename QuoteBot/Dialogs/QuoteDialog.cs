using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading;

namespace QuoteBot.Dialogs
{
    [Serializable]
    public class QuoteDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            Thread.Sleep(3000);
            await context.PostAsync("Our best price for your vehicle is **£602.95**. Your reference is 14124-87123-89343 and the details can be viewed at https://secure.swinton.co.uk/swinton/startquote.launch?qsid=newbus&PolicyType=PC&brandName=default");

            context.Done<object>(new object());
        }
    }
}