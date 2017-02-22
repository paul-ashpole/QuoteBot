using Microsoft.Bot.Builder.FormFlow;
using System;

namespace QuoteBot.Models
{
    [Serializable]
    public class RiskData
    {
        [Prompt("What postcode is your vehicle kept at?")]
        public string Postcode;

        [Prompt("What is the registration number of your vehicle?")]
        public string Registration;

        [Prompt("What is your date of birth?")]
        public DateTime DateOfBirth;

        public static IForm<RiskData> BuildForm()
        {
            return new FormBuilder<RiskData>()
                .Message("We just need a few details to allow us to get you a quote for your car.")
                .Build();
        }
    }
}