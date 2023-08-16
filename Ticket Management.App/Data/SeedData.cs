using TicketManagement.App.Data.Context;
using TicketManagement.App.Data.Entities;

namespace TicketManagement.App.Data
{
    public static class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Trains.Any())
            {
                //var train1 = new Train
                //{
                //    Ad = "Başkent Express",
                //    Vagonlar = new List<Vagon>
                //    {
                //    new Vagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 68 },
                //    new Vagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 50 },
                //    new Vagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 80 },  
                //    new Vagon { Ad = "Vagon 4", Kapasite = 60, DoluKoltukAdet = 20 }
                //}
                //};

                //var train2 = new Train
                //{
                //    Ad = "Anadolu Express",
                //    Vagonlar = new List<Vagon>
                //{
                //    new Vagon { Ad = "Vagon 1", Kapasite = 110, DoluKoltukAdet = 70 },
                //    new Vagon { Ad = "Vagon 2", Kapasite = 95, DoluKoltukAdet = 55 },
                //    new Vagon { Ad = "Vagon 3", Kapasite = 85, DoluKoltukAdet = 75 }
                //}
                //};

                var train3 = new Train
                {
                    Ad = "Test Express",
                    Vagonlar = new List<Vagon>
                    {
                        new Vagon {Ad = "Vagon 1", Kapasite= 50, DoluKoltukAdet = 50},
                        new Vagon {Ad = "Vagon 2", Kapasite= 40, DoluKoltukAdet = 35}

                    }
                }; 

                context.AddRange(train3);
                context.SaveChanges();
            }
        }
    }
}
