namespace TicketManagement.App.Data.Entities
{
    public class Vagon : BaseEntity
    {
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
        public Guid TrainId { get; set; }
        public Train? Train { get; set; }

    }
}
