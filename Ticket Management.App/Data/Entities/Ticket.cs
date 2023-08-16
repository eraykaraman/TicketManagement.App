namespace TicketManagement.App.Data.Entities
{
    public class Ticket : BaseEntity
    {
        public Train Train { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
