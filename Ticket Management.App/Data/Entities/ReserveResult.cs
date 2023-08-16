namespace TicketManagement.App.Data.Entities
{
    public class ReserveResult
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
        public string Message { get; set; }
    }
}
