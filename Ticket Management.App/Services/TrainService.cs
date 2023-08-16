using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketManagement.App.Data.Context;
using TicketManagement.App.Data.Entities;
using TicketManagement.App.Services.Abstracts;

namespace TicketManagement.App.Services
{
    public class TrainService : IService<Train>
    {
        private readonly ApplicationDbContext _context;

        public TrainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Train entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Train>> GetAllAsync()
        {
            return await _context.Trains.AsNoTracking().ToListAsync();

        }

        public async Task<Train?> GetByFilter(Expression<Func<Train, bool>> filter)
        {
            var result = await _context.Trains.AsNoTracking().SingleOrDefaultAsync(filter);
            return result;
        }

        public async Task<Train?> GetByIdAsync(object id)
        {
            var result = await _context.Trains.FindAsync(id);

            if (result == null)
            {
                throw new Exception("ticket not found.");
            }
            else
            {
                return result;
            }
        }

        public async Task RemoveAsync(object id)
        {
            var result = await _context.Trains.FindAsync(id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("ticket not found.");

            }
        }

        public async Task UpdateAsync(Train entity)
        {
            var result = await _context.Trains.FindAsync(entity.Id);
            if (result != null)
            {
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }
    }
}
