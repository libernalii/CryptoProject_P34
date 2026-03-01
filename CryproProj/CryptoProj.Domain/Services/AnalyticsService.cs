using CryptoProj.Domain.Abstractions;
using CryptoProj.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProj.Domain.Services
{
    public class AnalyticsService
    {
        private readonly IAnalyticsRepository _repository;

        public AnalyticsService(IAnalyticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Analytics?> GetByCryptoIdAsync(Guid cryptoId)
        {
            return await _repository.GetByCryptocurrencyIdAsync(cryptoId);
        }

        public async Task<Analytics> CreateAsync(
            Guid cryptoId,
            decimal predictedPrice,
            decimal risk,
            decimal alpha,
            decimal beta)
        {
            var analytics = new Analytics
            {
                Id = Guid.NewGuid(),
                CryptocurrencyId = cryptoId,
                PredictedPriceUsd = predictedPrice,
                RiskScore = risk,
                Alpha = alpha,
                Beta = beta,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(analytics);
            return analytics;
        }

        public async Task<Analytics?> UpdateAsync(
            Guid cryptoId,
            decimal predictedPrice,
            decimal risk,
            decimal alpha,
            decimal beta)
        {
            var analytics = await _repository.GetByCryptocurrencyIdAsync(cryptoId);
            if (analytics == null) return null;

            analytics.PredictedPriceUsd = predictedPrice;
            analytics.RiskScore = risk;
            analytics.Alpha = alpha;
            analytics.Beta = beta;
            analytics.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(analytics);
            return analytics;
        }
    }
}
