using System.Collections.Generic;

namespace CovidTelegramBot.BotCommands.Interfaces
{
    public interface ITelegramCommandService
    {
        IEnumerable<ITelegramCommand> GetCommands();
    }
}
