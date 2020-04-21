using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using static FL.ProjectService.Project;

namespace FL.Client.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("start test project server");

            var channel1 = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProjectClient(channel1);
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

            Console.WriteLine("---------------------------------");
            Console.ReadKey();
        }
    }
}
