using Grpc.Core;

namespace GrpcCalculator.Services;

public class CalculatorService(ILogger<CalculatorService> logger) : Calculator.CalculatorBase
{
  public override Task<AddReply> Add(AddRequest request, ServerCallContext context)
  {
    logger.LogInformation("The message is received with payload lhs: {lhs}, rhs: {rhs}", request.Lhs, request.Rhs);

    return Task.FromResult(new AddReply
    {
      Sum = request.Lhs + request.Rhs
    });
  }
}
