using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketManagement.App.Data.Context;
using TicketManagement.App.Data.Entities;
using TicketManagement.App.Services.Abstracts;

namespace TicketManagement.App.Services
{
    public class VagonsService : IService<Vagon>
    {
        private readonly ApplicationDbContext _context;

        public VagonsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Vagon entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Vagon>> GetAllAsync()
        {
            return await _context.Vagons.AsNoTracking().ToListAsync();
        }

        public async Task<Vagon?> GetByFilter(Expression<Func<Vagon, bool>> filter)
        {
            return await _context.Vagons.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<Vagon?> GetByIdAsync(object id)
        {
            var result = await _context.Vagons.FindAsync(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("vagon not found");
            }
            
        }

        public async Task RemoveAsync(object id)
        {
            var result = await _context.Vagons.FindAsync(id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("vagon not found");
            }
        }

        public async Task UpdateAsync(Vagon entity)
        {
            var result = await _context.Vagons.FindAsync(entity.Id);
            if (result != null)
            {
                _context.Update(result);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("vagon not found");
            }
        }
    }
}
