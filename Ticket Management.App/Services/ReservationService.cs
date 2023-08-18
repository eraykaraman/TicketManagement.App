using Microsoft.EntityFrameworkCore;
using TicketManagement.App.Data.Context;
using TicketManagement.App.Data.Entities;

namespace TicketManagement.App.Services
{
    public class ReservationService
    {

        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ReserveResult Reserve(ReservationRequest request)
        {
            var result = new ReserveResult();

            try
            {
                var selectedTrain = _context.Trains
                    .Include(t => t.Vagonlar)
                    .FirstOrDefault(t => t.Ad == request.Tren.Ad);

                if (selectedTrain == null)
                {
                    result.RezervasyonYapilabilir = false;
                    result.YerlesimAyrinti = new List<YerlesimAyrinti>();
                    result.Message = "Tren bulunamadı";
                    return result;
                }

                var totalPassengerCount = request.RezervasyonYapilacakKisiSayisi;
                var yerlesimAyrinti = new List<YerlesimAyrinti>();

                foreach (var vagon in selectedTrain.Vagonlar)
                {
                    var availableSeats = vagon.Kapasite - vagon.DoluKoltukAdet;
                    var maxCapacity = (int)(vagon.Kapasite * 0.7);

                    if (!request.KisilerFarkliVagonlaraYerlestirilebilir && availableSeats < totalPassengerCount)
                    {
                        continue; // we cannot fit all passengers in this vagon
                    }

                    var kisiSayisi = Math.Min(totalPassengerCount, availableSeats);

                    yerlesimAyrinti.Add(new YerlesimAyrinti
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = kisiSayisi
                    });

                    totalPassengerCount -= kisiSayisi;

                    if (totalPassengerCount <= 0)
                        break;
                }

                if (yerlesimAyrinti.Count == 0)
                {
                    result.RezervasyonYapilabilir = false;
                    result.YerlesimAyrinti = new List<YerlesimAyrinti>();
                    result.Message = "Müsait vagon bulunamadı.";
                    return result;
                }

                result.RezervasyonYapilabilir = true;
                result.YerlesimAyrinti = yerlesimAyrinti;
                result.Message = "Rezervasyon başarılı";
            }
            catch (Exception ex)
            {
                result.RezervasyonYapilabilir = false;
                result.Message = "Rezervasyon oluşturulurken bir sorunla karşılaşıldı.";
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }

}

    

