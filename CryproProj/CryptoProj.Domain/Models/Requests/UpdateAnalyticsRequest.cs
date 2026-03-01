using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProj.Domain.Models.Requests
{
    public class UpdateAnalyticsRequest
    {
        public decimal PredictedPriceUsd { get; set; }
        public decimal RiskScore { get; set; }
        public decimal Alpha { get; set; }
        public decimal Beta { get; set; }
    }
}
