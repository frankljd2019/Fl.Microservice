using System;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using static FL.ProjectService.Project;

namespace FL.Client.Test
{
    class Program
    {
        static async void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProjectClient(channel);
            var project = await client.GetAsync(
                new ProjectService.ProjectRequest { Id = 1 });
            Console.WriteLine("test Get-(Project Server) : " + project.Code + "" + project.Name);

            var projectList = await client.ListAsync(new Empty());
            foreach (var item in projectList.Project)
            {
                Console.WriteLine("test Get-(Project Server) : " + item.Code + "" + item.Name);

            }
            Console.ReadKey();
        }
    }
}
