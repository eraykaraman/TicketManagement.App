using Microsoft.EntityFrameworkCore;
using TicketManagement.App.Data.Entities;

namespace TicketManagement.App.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Vagon> Vagons { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vagon>()
             .HasOne(v => v.Train)          // Each Vagons belongs to one Train
             .WithMany(t => t.Vagonlar)     // Each Train can have many Vagons
             .HasForeignKey(v => v.TrainId);
        }

    }
}
