using System;

namespace CovidTelegramBot.Models
{
    public class CovidStatistic
    {
        public string State { get; set; }
        public string Country { get; set; }
        public string LastUpdate { get; set; }
        public int ConfirmedCases { get; set; }
        public int Deaths { get; set; }

        public override string ToString()
            => $"Country: {Country}{Environment.NewLine}State: {State}{Environment.NewLine}"
             + $"Confirmed cases: {ConfirmedCases}{Environment.NewLine}Deaths: {Deaths}{Environment.NewLine}"
             + $"Last update: {LastUpdate}";
    }
}
