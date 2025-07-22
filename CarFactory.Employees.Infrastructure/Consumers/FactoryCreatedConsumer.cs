using CarFactory.Employees.Contracts.Events;
using MassTransit;

namespace CarFactory.Employees.Infrastructure.Consumers;

public class FactoryCreatedConsumer : IConsumer<IFactoryCreated>
{
    public Task Consume(ConsumeContext<IFactoryCreated> context)
    {
        var message = context.Message;
        Console.WriteLine($"New Fabric created: {message.Name} with number of employees: {message.NumberOfEmployees}");

        return Task.CompletedTask;
    }
}
