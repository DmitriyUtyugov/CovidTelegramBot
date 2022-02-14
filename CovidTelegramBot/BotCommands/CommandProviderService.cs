using CovidTelegramBot.BotCommands.Interfaces;
using CovidTelegramBot.Infrastructure;
using CovidTelegramBot.Infrastructure.Interfaces;
using CovidTelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTelegramBot.BotCommands
{
    public class CommandProviderService : ITelegramCommandService
    {
        private IEnumerable<ITelegramCommand> telegramCommands;
        private IFileDownloader fileDownloader;
        private IRepository repository;

        // add commands to ctor when extending telegram command pull
        public CommandProviderService(IFileDownloader fileDownloader, IRepository repository)
        {
            this.fileDownloader = fileDownloader;
            this.repository = repository;
            telegramCommands = new List<ITelegramCommand>
            {
                new StartTelegramCommand(fileDownloader, repository)
            };
        }

        public IEnumerable<ITelegramCommand> GetCommands()
            => telegramCommands;
    }
}
