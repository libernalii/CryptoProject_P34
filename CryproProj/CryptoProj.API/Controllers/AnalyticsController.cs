using CryptoProj.Domain.Models;
using CryptoProj.Domain.Models.Requests;
using CryptoProj.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoProj.API.Controllers
{
    [ApiController]
    [Route("api/v1/analytics")]
    public class AnalyticsController : ControllerBase
    {
        private readonly AnalyticsService _service;

        public AnalyticsController(AnalyticsService service)
        {
            _service = service;
        }

        [HttpGet("{cryptoId:guid}")]
        public async Task<IActionResult> Get(Guid cryptoId)
        {
            var analytics = await _service.GetByCryptoIdAsync(cryptoId);
            if (analytics == null) return NotFound();

            return Ok(new AnalyticsResponse
            {
                Id = analytics.Id,
                CryptocurrencyId = analytics.CryptocurrencyId,
                PredictedPriceUsd = analytics.PredictedPriceUsd,
                RiskScore = analytics.RiskScore,
                Alpha = analytics.Alpha,
                Beta = analytics.Beta,
                CreatedAt = analytics.CreatedAt
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnalyticsRequest request)
        {
            var analytics = await _service.CreateAsync(
                request.CryptocurrencyId,
                request.PredictedPriceUsd,
                request.RiskScore,
                request.Alpha,
                request.Beta);

            return Ok(analytics.Id);
        }

        [HttpPut("{cryptoId:guid}")]
        public async Task<IActionResult> Update(
            Guid cryptoId,
            UpdateAnalyticsRequest request)
        {
            var analytics = await _service.UpdateAsync(
                cryptoId,
                request.PredictedPriceUsd,
                request.RiskScore,
                request.Alpha,
                request.Beta);

            if (analytics == null) return NotFound();

            return Ok();
        }
    }
}
