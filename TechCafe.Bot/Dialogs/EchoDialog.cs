using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;
using TechCafe.Bot.CryptoTracker;
using TechCafe.Bot.WC2018;
using System.Linq;
using TechCafe.Bot.WC2018.Extension;
using System.Text;

namespace TechCafe.Bot
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        protected int count = 1;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text == "reset")
            {
                PromptDialog.Confirm(
                    context,
                    AfterResetAsync,
                    "Are you sure you want to reset the count?",
                    "Didn't get that!",
                    promptStyle: PromptStyle.Auto);
            }
            else
            {
                var text = message.Text.Replace("TechcafeBot", string.Empty).Trim();
                if (text.ToLower().StartsWith("wc") && text.ToLower().Contains("nextmatch"))
                {
                    var matches = WC2018LookupService.Instance.GetNextMatches();
                    var matchesString = matches.Select(m => m.ToText()).ToArray();
                    var result =  string.Join("\n\n", matchesString);
                    await context.PostAsync(result);
                }
                else if (text.ToLower().StartsWith("wc") && text.ToLower().Contains("score"))
                {
                    var matches = WC2018LookupService.Instance.GetScores();
                    var matchesString = matches.Select(m => m.ToScore()).ToArray();
                    var result = string.Join("\n\n", matchesString);
                    await context.PostAsync(result);
                }
                else if (text.ToLower().StartsWith("coin"))
                {
                    var coin = text.Split(' ')[1];
                    var coinInfo = CoinLookupService.Instance.Lookup(coin);
                    if (coinInfo != null)
                    {
                        var data = CoinMarketCapService.Instance.GetCurrencyInfo(coinInfo.Id).Data;
                        var result = $"{data.Name} : {data.Quote.Usd.Price:C} - Vol24h {data.Quote.Usd.Volume24h:C}";
                        result += " | Change 1d " + (data.Quote.Usd.PercentChange24h >= 0 ? "(up) " : "(down) ") + data.Quote.Usd.PercentChange24h + "%";
                        result += " | Change 7d " + (data.Quote.Usd.PercentChange7d >= 0 ? "(up) " : "(down) ") + data.Quote.Usd.PercentChange7d + "%";
                        await context.PostAsync(result);
                    }
                    else
                    {
                        await context.PostAsync($"{message.Text} - :)");
                    }
                }
                else if (text.ToLower().StartsWith("summon"))
                {
                    var name = text.Split(' ')[1];
                    if (name == "Bu")
                    {
                        var result = "@daolavi @Dao @Bu @Burin";
                        await context.PostAsync(result);
                    }
                }
                else
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("coin <code>           : coin price inquiry");
                    stringBuilder.AppendLine("summon <Bu>           : coin price inquiry");
                    var result = stringBuilder.ToString();
                    await context.PostAsync(result);
                }

                context.Wait(MessageReceivedAsync);
                
            }
        }

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            context.Wait(MessageReceivedAsync);
        }

    }
}