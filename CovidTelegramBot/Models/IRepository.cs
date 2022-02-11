using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTelegramBot.Models
{
    public interface IRepository
    {
        IEnumerable<CovidStatistic> CovidStatistics { get; }
        void AddStatistic(CovidStatistic covidStatistic);
        void ClearStatistics();
    }
}
