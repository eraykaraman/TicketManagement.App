namespace TicketManagement.App.Data.Entities
{
    public class ReservationRequest
    {
        public Train Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
