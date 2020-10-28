using System;
using System.Threading.Tasks;

using Grpc.Net.Client;

namespace GrpcGreeterClient
{
  class Program
  {
    static async Task Main(string[] args)
    {
      // The port number(5001) must match the port of the gRPC server.
      using var channel = GrpcChannel.ForAddress("https://localhost:5001");
      var client = new Greeter.GreeterClient(channel);
      try
      {
        var reply = await client.SayHelloAsync(
                        new HelloRequest { Name = "GrpcClient" });
        Console.WriteLine("Connected: " + reply.Message);
        Console.ReadKey();
      }
      catch (Exception error)
      {
        Console.WriteLine("Not connected: " + error.Message);
        Console.ReadKey();
      }
    }
  }
}
