using CarFactory.Employees.Contracts.Events;
using MassTransit;

namespace CarFactory.Employees.Infrastructure.Consumers;

public class FactoryCreatedConsumer : IConsumer<IFactoryCreated>
{
    
    public FactoryCreatedConsumer()
    {
    }

    public Task Consume(ConsumeContext<IFactoryCreated> context)
    {

        throw new NotImplementedException();
    }
}
