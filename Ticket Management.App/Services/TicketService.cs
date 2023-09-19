using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketManagement.App.Data.Context;
using TicketManagement.App.Data.Entities;
using TicketManagement.App.Services.Abstracts;

namespace TicketManagement.App.Services
{
    public class TicketService : IService<Ticket>
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Ticket entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.AsNoTracking().ToListAsync();
        }

        public async Task<Ticket?> GetByFilter(Expression<Func<Ticket, bool>> filter)
        {
            var result = await _context.Tickets.AsNoTracking().SingleOrDefaultAsync(filter);
            return result;
        }

        public async Task<Ticket?> GetByIdAsync(object id)
        {
            var result = await _context.Tickets.FindAsync(id);

            if(result == null)
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
            var result = await _context.Tickets.FindAsync(id);
            if(result != null)
            {
                 _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("ticket not found.");

            }

        }

        public async Task UpdateAsync(Ticket entity)
        {
            var result = await _context.Tickets.FindAsync(entity.Id);
            if(result != null)
            {
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("ticket not found.");
            }
        }

    }
}
