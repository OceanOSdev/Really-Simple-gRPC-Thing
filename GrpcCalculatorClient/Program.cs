using Grpc.Net.Client;
using GrpcCalculatorClient;

using var channel = GrpcChannel.ForAddress("https://localhost:7169");
var client = new Calculator.CalculatorClient(channel);

Console.WriteLine("Enter first number:");
var input = Console.ReadLine();
int lhs = 0;

if (!int.TryParse(input, out lhs))
{
  Console.WriteLine("Error parsing int. Exiting...");
  return;
}

Console.WriteLine("Enter second number:");
input = Console.ReadLine();
int rhs = 0;

if (!int.TryParse(input, out rhs))
{
  Console.WriteLine("Error parsing int. Exiting...");
  return;
}

var reply = await client.AddAsync(
    new AddRequest { Lhs = lhs, Rhs = rhs });

Console.WriteLine($"{lhs} + {rhs} = " + reply.Sum);
