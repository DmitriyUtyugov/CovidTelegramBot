using CovidTelegramBot.Models;
using Sylvan.Data.Csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTelegramBot.Infrastructure
{
    public class CsvParser
    {
        public static IEnumerable<CovidStatistic> ParseCsv(string fileName)
        {
            using var csv = CsvDataReader.Create(fileName);

            var state = csv.GetOrdinal("Province_State");
            var country = csv.GetOrdinal("Country_Region");
            var lastUpdate = csv.GetOrdinal("Last_Update");
            var confirmedCases = csv.GetOrdinal("Confirmed");
            var deaths = csv.GetOrdinal("Deaths");

            while (csv.Read())
            {
                yield return new CovidStatistic
                {
                    State = csv.GetString(state),
                    Country = csv.GetString(country),
                    LastUpdate = csv.GetString(lastUpdate),
                    ConfirmedCases = csv.GetInt32(confirmedCases),
                    Deaths = csv.GetInt32(deaths)
                };
            }
        }
    }
}
