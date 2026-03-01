using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProj.Domain.Models
{
    public class AnalyticsResponse
    {
        public Guid Id { get; set; }
        public Guid CryptocurrencyId { get; set; }
        public decimal PredictedPriceUsd { get; set; }
        public decimal RiskScore { get; set; }
        public decimal Alpha { get; set; }
        public decimal Beta { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
