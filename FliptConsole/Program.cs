using System;
using System.Text.Json;
using Flipt;
using Grpc.Core;

namespace FliptConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:9000", ChannelCredentials.Insecure);
            var client = new Flipt.Flipt.FliptClient(channel);
            var entityId = Guid.NewGuid().ToString();

            var response = client.Evaluate(new EvaluationRequest {EntityId = entityId, FlagKey = "new-login"});
            Console.WriteLine(JsonSerializer.Serialize(response));

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}