using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using static FL.ProjectService.Project;
using static FL.KpiService.Kpi;

namespace FL.Client.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("start test project server");

            var channelProject = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProjectClient(channelProject);
            var project = await client.GetAsync(
                new ProjectService.ProjectRequest { Id = 1 });
            Console.WriteLine("test Get-(Project Server) : " + project.Code + "" + project.Name);

            var projectList = await client.ListAsync(new Empty());
            foreach (var item in projectList.Project)
            {
                Console.WriteLine("test Get-(Project Server) : " + item.Code + "" + item.Name);

            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("start test kpi server");

            var channelkpi = GrpcChannel.ForAddress("https://localhost:5002");
            var clientKpi = new KpiClient(channelkpi);
            var kpi = await clientKpi.GetAsync(
                new KpiService.KpiRequest { Id = 1 });
            Console.WriteLine("test Get-(Kpi Server) : " + kpi.Name + "" + kpi.Status.ToString());

            var kpiList = await clientKpi.PagedListAsync(new KpiService.KpiPagedRequest { PageIndex = 1, PageSize = 2 });
            foreach (var item in kpiList.Kpi)
            {
                Console.WriteLine("test Get-(Kpi Server) : " + item.Name + "" + item.Status.ToString());

            }

            Console.WriteLine("---------------------------------");
            Console.ReadKey();
        }
    }
}
