namespace CovidTelegramBot.Models
{
    public class CovidStatistic
    {
        public string State { get; set; }
        public string Country { get; set; }
        public string LastUpdate { get; set; }
        public int ConfirmedCases { get; set; }
        public int Deaths { get; set; }
    }
}
