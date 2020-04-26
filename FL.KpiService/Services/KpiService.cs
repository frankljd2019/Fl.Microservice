using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace FL.KpiService
{
    public class KpiService : Kpi.KpiBase
    {
        private readonly ILogger<KpiService> _logger;
        public KpiService(ILogger<KpiService> logger)
        {
            _logger = logger;
        }

        public override Task<KpiModel> Get(KpiRequest request, ServerCallContext context)
        {
            return Task.FromResult(new KpiModel
            {
                Name = "kpi cashflow",
                Status = KpiStatus.High
            });
        }


        public override Task<KpiList> PagedList(KpiPagedRequest request, ServerCallContext context)
        {
            var result = new KpiList();
            result.Kpi.Add(new KpiModel
            {
                Name = "kpi cashflow",
                Status = KpiStatus.High
            });
            result.Kpi.Add(new KpiModel
            {
                Name = "kpi funding",
                Status = KpiStatus.Low
            });
            return Task.FromResult(result);
        }
    }
}
