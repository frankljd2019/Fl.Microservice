using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace FL.ProjectService
{
    public class ProjectService : Project.ProjectBase
    {
        private readonly ILogger<ProjectService> _logger;
        public ProjectService(ILogger<ProjectService> logger)
        {
            _logger = logger;
        }

        public override Task<ProjectModel> Get(ProjectRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ProjectModel
            {
                Name = "admin",
                Code = "01"
            });
        }

        public override Task<ProjectList> List(Empty request, ServerCallContext context)
        {
            var result = new ProjectList();
            result.Project.Add(new ProjectModel
            {
                Name = "amousa",
                Code = "002"
            });
            result.Project.Add(new ProjectModel
            {
                Name = "kevin",
                Code = "003"
            });
            return Task.FromResult(result);
        }
    }
}
