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

        // add commands to ctor when extending telegram command pull
        public CommandProviderService()
        {
            telegramCommands = new List<ITelegramCommand>
            {
                new StartTelegramCommand(new FileDownloader(), new LocalRepository())
            };
        }

        public IEnumerable<ITelegramCommand> GetCommands()
            => telegramCommands;
    }
}
