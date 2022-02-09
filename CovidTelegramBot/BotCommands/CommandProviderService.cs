using CovidTelegramBot.BotCommands.Interfaces;
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
                new StartTelegramCommand()
            };
        }

        public IEnumerable<ITelegramCommand> GetCommands()
            => telegramCommands;
    }
}
