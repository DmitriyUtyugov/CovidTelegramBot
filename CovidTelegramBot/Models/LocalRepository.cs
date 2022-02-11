using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTelegramBot.Models
{
    public class LocalRepository : IRepository
    {
        private List<CovidStatistic> statistics;

        public IEnumerable<CovidStatistic> CovidStatistics => statistics;

        public void AddStatistic(CovidStatistic covidStatistic)
        {
            statistics.Add(covidStatistic);
        }

        public void ClearStatistics()
        {
            statistics.Clear();
        }
    }
}
