namespace TicketManagement.App.Data.Entities
{
    public class Train : BaseEntity
    {
        public string Ad { get; set; }
        public List<Vagon> Vagonlar { get; set; }

    }
}
