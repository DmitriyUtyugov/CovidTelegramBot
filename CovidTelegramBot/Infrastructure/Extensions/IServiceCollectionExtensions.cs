using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CovidTelegramBot.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramBotClient(this IServiceCollection services, IConfiguration configuration)
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient(configuration["TelegramBot:TelegramToken"]);

            //using ngrok to emulate, changes every restart of ngrok
            string telegramBotWebHook = $"{configuration["TelegramBot:WebHook"]}";
            telegramBotClient.SetWebhookAsync(telegramBotWebHook).Wait();

            return services.AddTransient<ITelegramBotClient>(x => telegramBotClient);
        }
    }
}
