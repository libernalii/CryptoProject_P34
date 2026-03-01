using CryptoProj.Domain.Abstractions;
using CryptoProj.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoProj.Storage.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly CryptoContext _context;

        public AnalyticsRepository(CryptoContext context)
        {
            _context = context;
        }

        public async Task<Analytics?> GetByCryptocurrencyIdAsync(Guid cryptoId)
        {
            return await _context.Analytics
                .FirstOrDefaultAsync(a => a.CryptocurrencyId == cryptoId);
        }

        public async Task AddAsync(Analytics analytics)
        {
            await _context.Analytics.AddAsync(analytics);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Analytics analytics)
        {
            _context.Analytics.Update(analytics);
            await _context.SaveChangesAsync();
        }
    }
}
