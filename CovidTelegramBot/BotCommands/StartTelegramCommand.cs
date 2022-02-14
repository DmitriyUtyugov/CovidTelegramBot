using CovidTelegramBot.BotCommands.Interfaces;
using CovidTelegramBot.Infrastructure.Interfaces;
using CovidTelegramBot.Models;
using System;
using System.Threading.Tasks;
using Sylvan.Data.Csv;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Linq;

namespace CovidTelegramBot.BotCommands
{
    public class StartTelegramCommand : ITelegramCommand
    {
        private IFileDownloader fileDownloader;
        private IRepository repository;

        private string today = DateTime.Today.AddDays(-1).ToString("MM-dd-yyyy");
        private readonly Uri statsForToday = 
            new Uri($"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/{DateTime.Today.AddDays(-1).ToString("MM-dd-yyyy")}.csv");

        public StartTelegramCommand(IFileDownloader fileDownloader, IRepository repository)
        {
            this.fileDownloader = fileDownloader;
            this.repository = repository;
        }

        public string Name => @"/start";

        public bool Contains(Message message)
        {
            return message.Type == MessageType.Text
                 ? message.Text.Contains(Name)
                 : false;
        }

        public async Task ExecuteCommand(Message message, ITelegramBotClient telegramBotClient)
        {
            if (fileDownloader.FileExists(statsForToday))
            {
                repository.ClearStatistics();
                fileDownloader.GetFileFromUrl(statsForToday);
                ParseCsv($"{today}.csv");
                string messageToSend = repository.CovidStatistics
                    .FirstOrDefault(s => s.State
                    .Contains(message.Text.Substring(7), 
                              StringComparison.InvariantCultureIgnoreCase)).ToString();

                await telegramBotClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                         text: messageToSend);
            }
            else
            {
                await telegramBotClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                         text: "No fresh stats yet...");
            }
        }

        private void ParseCsv(string fileName)
        {
            using var csv = CsvDataReader.Create(fileName);

            var state = csv.GetOrdinal("Province_State");
            var country = csv.GetOrdinal("Country_Region");
            var lastUpdate = csv.GetOrdinal("Last_Update");
            var confirmedCases = csv.GetOrdinal("Confirmed");
            var deaths = csv.GetOrdinal("Deaths");

            while (csv.Read())
            {
                repository.AddStatistic(new CovidStatistic
                {
                    State = csv.GetString(state),
                    Country = csv.GetString(country),
                    LastUpdate = csv.GetString(lastUpdate),
                    ConfirmedCases = csv.GetInt32(confirmedCases),
                    Deaths = csv.GetInt32(deaths)
                });
            }
        }
    }
}
